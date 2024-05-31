using eShelf_website.Factory;
using eShelf_website.Model;
using eShelf_website.Repository;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace eShelf_website.Controller
{
    public class ViewCartController
    {
        PaymentMethodRepository pmRepo = new PaymentMethodRepository();
        TransactionRepository transRepo = new TransactionRepository();
        CartRepository cartRepo = new CartRepository();
        BookRepository bookRepo = new BookRepository();
        CatalogRepository catalogRepo = new CatalogRepository();
        UserRepository userRepo = new UserRepository();

        public User getUser(string id)
        {
            return userRepo.getUser(id);
        }
        public List<PaymentMethod> getAllPaymentMethods()
        {
            List<PaymentMethod> pms = pmRepo.getAllPaymentMethods();
            return pms;
        }

        public string getTransactionID(string userId)
        {
            string transactionID = transRepo.getTransactionId(userId);
            return transactionID;
        }

        public List<Cart> getAllCarts(string transactionId)
        {
            List<Cart> carts = cartRepo.getCarts(transactionId);
            return carts;
        }

        public Book getBook(string bookId)
        {
            Book book = bookRepo.getBook(bookId);
            return book;
        }

        public void checkOut(string userId, string pm)
        {
            string transactionID = transRepo.getTransactionId(userId);
            string pmID = pmRepo.getPMID(pm);

            transRepo.checkOut(transactionID, pmID);
        }

        public bool isEmpty(string userId)
        {
            string transactionId = transRepo.getTransactionId(userId);
            
            if (String.IsNullOrEmpty(transactionId)) 
                return true;

            List<Cart> carts = cartRepo.getCarts(transactionId);
            if (carts == null) 
                return true;
            return false;
        }

        private bool isPhysical(string transactionID)
        {
            List<Cart> carts = cartRepo.getCarts(transactionID);
            foreach(var c in carts)
            {
                if (c.Type == "Physical") return true;
            }
            return false;
        }

        public bool isAddress(string userId)
        {
            string transactionId = transRepo.getTransactionId(userId);
            User user = userRepo.getUser(userId);

            if (isPhysical(transactionId) && String.IsNullOrEmpty(user.BillingAddress))
            {
                return true;
            }
            return false;
        }

        public void minQty(string transactionId, string bookId, string type)
        {
            Catalog catalog = catalogRepo.getCatalog(bookId);
            Cart cart = cartRepo.getCart(transactionId, bookId, type);

            int cartQty = cart.Quantity;
            cartQty -= 1;

            if(cartQty <= 0)
            {
                return;
            }

            int catalogQty = 0;

            if(type == "Physical")
            {
                catalogQty = catalog.QuantityPhysical + 1;
            }
            else
            {
                catalogQty = catalog.QuantityDigital + 1;
            }

            cartRepo.setQtyCart(transactionId, bookId, type, cartQty);
            catalogRepo.setQtyCatalog(bookId, type, catalogQty);
        }

        public void addQty(string transactionId, string bookId, string type)
        {
            Catalog catalog = catalogRepo.getCatalog(bookId);
            Cart cart = cartRepo.getCart(transactionId, bookId, type);

            int cartQty = cart.Quantity;
            int catalogQty = 0;

            if (type == "Physical")
            {
                catalogQty = catalog.QuantityPhysical - 1;
            }
            else
            {
                catalogQty = catalog.QuantityDigital - 1;
            }

            if(catalogQty <= 0)
            {
                return;
            }

            cartQty += 1;

            cartRepo.setQtyCart(transactionId, bookId, type, cartQty);
            catalogRepo.setQtyCatalog(bookId, type, catalogQty);
        }

        public void delItem(string transactionId, string bookId, string type)
        {
            cartRepo.delCart(transactionId, bookId, type);
        }

        public HtmlGenericControl setOderDetail(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";

            HtmlGenericControl divContainerOrderDetail = new HtmlGenericControl("div");
            divContainerOrderDetail.Attributes["class"] = "ContainerOrderDetail";

            Label BookOrderTitle = new Label();
            BookOrderTitle.ID = "BookOrderTitle_" + formatId;
            BookOrderTitle.Text = $"{c.Quantity}x {b.Title} ({c.Type})";

            Label BookOrderPrice = new Label();
            BookOrderPrice.ID = "BookOrderPrice_" + formatId;
            BookOrderPrice.Text = "Rp. " + (c.Quantity * b.Price).ToString("###,###,##0.00");

            divContainerOrderDetail.Controls.Add(BookOrderTitle);
            divContainerOrderDetail.Controls.Add(BookOrderPrice);

            return divContainerOrderDetail;

        }
    
        public HtmlGenericControl setContainerItem()
        {
            HtmlGenericControl divContainerItem = new HtmlGenericControl("div");
            divContainerItem.Attributes["class"] = "ContainerItem";
            return divContainerItem;
        }

        public HtmlGenericControl setBookCover(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";

            HtmlGenericControl bookCover = new HtmlGenericControl("div");
            bookCover.Attributes["class"] = "BookCover";
            bookCover.Attributes["style"] = $"background-image: url('{b.Cover}');"; //Cover

            return bookCover;
        }
        
        public HtmlGenericControl setContainerBookDescription()
        {
            HtmlGenericControl divContainerBookDescription = new HtmlGenericControl("div");
            divContainerBookDescription.Attributes["class"] = "ContainerBookDescription";
            return divContainerBookDescription;
        }
        public HtmlGenericControl setBookDescriptionHeader(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";

            HtmlGenericControl divContainerBookDescriptionHeader = new HtmlGenericControl("div");
            divContainerBookDescriptionHeader.Attributes["class"] = "ContainerBookDescriptionHeader";

            Label LBBookTitle = new Label();
            LBBookTitle.CssClass = "BookTitle";
            LBBookTitle.ID = "LBtitle_" + formatId;
            LBBookTitle.Text = b.Title; //Title


            Label LBBookAuthor = new Label();
            LBBookAuthor.CssClass = "BookAuthor";
            LBBookAuthor.ID = "LBAuthor_" + formatId;
            LBBookAuthor.Text = b.Author; //Author

            Label LBBookGenre = new Label();
            LBBookGenre.CssClass = "BookGenre";
            LBBookGenre.ID = "LBgenre_" + formatId;
            LBBookGenre.Text = b.Genre + " . " + c.Type; //Genre

            divContainerBookDescriptionHeader.Controls.Add(LBBookTitle);
            divContainerBookDescriptionHeader.Controls.Add(LBBookAuthor);
            divContainerBookDescriptionHeader.Controls.Add(LBBookGenre);

            return divContainerBookDescriptionHeader;
        }

        public HtmlGenericControl setBookDesciptionTail()
        {
            HtmlGenericControl divContainerBookDescriptionTail = new HtmlGenericControl("div");
            divContainerBookDescriptionTail.Attributes["class"] = "ContainerBookDescriptionTail";
            return divContainerBookDescriptionTail;
        }
    
        public Label setBDTPrice(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";
            Label LBBookPrice = new Label();
            LBBookPrice.CssClass = "BookPrice";
            LBBookPrice.ID = "LBprice_" + formatId;
            LBBookPrice.Text = "Rp. " + (b.Price * c.Quantity).ToString("###,###,##0.00"); //Price;

            return LBBookPrice;
        }

        public HtmlGenericControl setContainerCartButton()
        {
            HtmlGenericControl divContainerCartButton = new HtmlGenericControl("div");
            divContainerCartButton.Attributes["class"] = "ContainerCartButton";
            return divContainerCartButton;
        }
    
        public Button setBTNdelete(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";
            Button BTNdelete = new Button();
            BTNdelete.ID = "BTNdelete_" + formatId;
            BTNdelete.CssClass = "BTNdelete BTNcart";
            return BTNdelete;
        }
        public HtmlGenericControl setContainerUpdate()
        {
            HtmlGenericControl divContainerUpdate = new HtmlGenericControl("div");
            divContainerUpdate.Attributes["class"] = "ContainerUpdate";
            return divContainerUpdate;
        }
    
        public Button setBTNminItem(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";
            Button BTNminItem = new Button();
            BTNminItem.ID = "BTNminItem_" + formatId;
            BTNminItem.CssClass = "BTNupdate BTNcart";
            BTNminItem.Text = "-";
            return BTNminItem;
        }

        public Label setBookQuantity(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";
            Label BookQuantity = new Label();
            BookQuantity.ID = "BookQuantity_" + formatId;
            BookQuantity.CssClass = "BookQuantity";
            BookQuantity.Text = c.Quantity.ToString();
            return BookQuantity;
        }
        
        public Button setBTNmaxItem(Cart c, Book b)
        {
            string formatId = $"{c.Id},{c.BookID},{c.Type}";
            Button BTNmaxItem = new Button();
            BTNmaxItem.ID = "BTNmaxItem_" + formatId;
            BTNmaxItem.CssClass = "BTNupdate BTNcart";
            BTNmaxItem.Text = "+";
            return BTNmaxItem;
        }

        public HtmlGenericControl setCartLine()
        {
            HtmlGenericControl CartLine = new HtmlGenericControl("div");
            CartLine.Attributes["class"] = "CartLine";
            return CartLine;
        }
    }
}