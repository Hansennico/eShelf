using eShelf_website.Model;
using eShelf_website.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.Controller
{
    public class HomeController
    {
        BookRepository bookRepo = new BookRepository();

        public List<Book> getAllBooks()
        {
            List<Book> book = bookRepo.getAllBook();
            return book;
        }

        public List<Book> getAllBooks(string text)
        {
            List<Book> book = bookRepo.getAllBook(text);
            return book;
        }

        public List<string> getGenres()
        {
            List<string> genres = bookRepo.getGenres();
            return genres;
        }

        public HtmlGenericControl addCategoryRB(string g)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = "RBcontainerCategoryItem_" + g;
            div.Attributes["class"] = "RBcontainerCategoryItem";


            RadioButton button = new RadioButton();
            button.Text = g;
            button.GroupName = "categoryItem";
            button.CssClass = "RBcategoryItem";
            button.ID = "RBcategoryItem_" + g;

            div.Controls.Add(button);
            return div;
        }

        public LinkButton addViewBook(Book b)
        {
            LinkButton button = new LinkButton();
            button.CssClass = "ContainerItem";
            button.ID = "Item_" + b.Id;

            

            HtmlGenericControl divCover = new HtmlGenericControl("div");
            divCover.Attributes["class"] = "itemBookCover";
            divCover.Attributes["style"] = $"background-image: url('{b.Cover}');";



            Label LabelTitle = new Label();
            LabelTitle.CssClass = "itemTitle";
            LabelTitle.Text = b.Title;

            Label LabelAuthor = new Label();
            LabelAuthor.CssClass = "itemAuthor";
            LabelAuthor.Text = b.Author;

            Label LabelPrice = new Label();
            LabelPrice.CssClass = "itemPrice";
            LabelPrice.Text = "Rp " + b.Price.ToString("###,###,##0.00");

            HtmlGenericControl divRating = new HtmlGenericControl("div");
            divRating.Attributes["class"] = "ContainerItemRating";

            Image ratingImg = new Image();
            ratingImg.ImageUrl = "../Style/Icon/star.png";

            Label LabelRating = new Label();
            LabelRating.Text = b.Rating.ToString();

            divRating.Controls.Add(ratingImg);
            divRating.Controls.Add(LabelRating);

            button.Controls.Add(divCover);
            button.Controls.Add(LabelTitle);
            button.Controls.Add(LabelAuthor);
            button.Controls.Add(LabelPrice);
            button.Controls.Add(divRating);

            return button;
        }
    
        public bool valdiateFilterPrice(string x)
        {
            if (!String.IsNullOrEmpty(x)) return true;
            return false;
        }

        public bool validateFilterPriceValue(int a, int b)
        {
            if (b > a || (a > 0 && b < 0) || (a < 0 && b > 0)) return true;
            return false;
        }


        public List<Book> getFilterBook(string genre)
        {
            List<Book> books = bookRepo.getFilterBook(genre);
            return books;
        }

        public List<Book> getFilterBook(string genre, int min, int max)
        {
            List<Book> books = bookRepo.getFilterBook(genre, min, max);
            return books;
        }

        public List<Book> getFilterBook(int min, int max)
        {
            List<Book> books = bookRepo.getFilterBook(min, max);
            return books;
        }

        public List<Book> getFilterBookMin(string genre, int min)
        {
            List<Book> books = bookRepo.getFilterBookMin(genre, min);
            return books;
        }

        public List<Book> getFilterBookMin(int min)
        {
            List<Book> books = bookRepo.getFilterBookMin(min);
            return books;
        }

        public List<Book> getFilterBookMax(string genre, int max)
        {
            List<Book> books = bookRepo.getFilterBookMax(genre, max);
            return books;
        }

        public List<Book> getFilterBookMax(int max)
        {
            List<Book> books = bookRepo.getFilterBookMax(max);
            return books;
        }
    }
}