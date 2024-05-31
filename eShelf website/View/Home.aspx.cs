using eShelf_website.Controller;
using eShelf_website.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eShelf_website.View
{
    public partial class Home : System.Web.UI.Page
    {
        HomeController homeCon = new HomeController();  
        protected void Page_Load(object sender, EventArgs e)
        {
            addCategory();
            addViewBook();
            LBshowFilter.Visible = false;
        }

        protected void BTNfilter_Click(object sender, EventArgs e)
        {
            string selectedGenre = getSelectedGenre();


            int minPrice = -999;
            int maxPrice = -999;
            if (homeCon.valdiateFilterPrice(TBminPrice.Text))
            {
                minPrice = Convert.ToInt32(TBminPrice.Text);
            }

            if (homeCon.valdiateFilterPrice(TBmaxPrice.Text))
            {
                maxPrice = Convert.ToInt32(TBmaxPrice.Text);
            }

            PNcontainerShowItem.Controls.Clear();
            if (!string.IsNullOrEmpty(selectedGenre) || homeCon.validateFilterPriceValue(minPrice, maxPrice))
            {
                LBshowFilter.Visible = true;
                setFilter(selectedGenre, minPrice, maxPrice);
            }
            else
            {
                LBshowFilter.Visible = false;
                addViewBook();
            }
        }

        private void setFilter(string selectedGenre, int minPrice, int maxPrice)
        {
            
            List<Book> books = null;

            if (!string.IsNullOrEmpty(selectedGenre))
            {
                if (minPrice > 0 && maxPrice > 0)
                {
                    books = homeCon.getFilterBook(selectedGenre, minPrice, maxPrice);
                    LBshowFilter.Text = selectedGenre + " | " + "Min Price: Rp. " + minPrice.ToString("###,###,##0.00")
                        + " | " + "Max Price: Rp. " + maxPrice.ToString("###,###,##0.00");
                }
                else if(minPrice > 0)
                {
                    books = homeCon.getFilterBookMin(selectedGenre, minPrice);
                    LBshowFilter.Text = selectedGenre + " | " + "Min Price: Rp. " + minPrice.ToString("###,###,##0.00");
                }
                else if(maxPrice > 0)
                {
                    books = homeCon.getFilterBookMax(selectedGenre, maxPrice);
                    LBshowFilter.Text = selectedGenre
                        + " | " + "Max Price: Rp. " + maxPrice.ToString("###,###,##0.00");
                }
                else
                {
                    books = homeCon.getFilterBook(selectedGenre);
                    LBshowFilter.Text = selectedGenre;
                }
            }
            else
            {
                if (minPrice > 0 && maxPrice > 0)
                {
                    books = homeCon.getFilterBook(minPrice, maxPrice);
                    LBshowFilter.Text = "Min Price: Rp. " + minPrice.ToString("###,###,##0.00")
                        + " | " + "Max Price: Rp. " + maxPrice.ToString("###,###,##0.00");
                }
                else if (minPrice > 0)
                {
                    books = homeCon.getFilterBookMin(minPrice);
                    LBshowFilter.Text = "Min Price: Rp. " + minPrice.ToString("###,###,##0.00");
                }
                else
                {
                    books = homeCon.getFilterBookMax(maxPrice);
                    LBshowFilter.Text = "Max Price: Rp. " + maxPrice.ToString("###,###,##0.00");
                }
            }


            
            foreach (var b in books)
            {
                addViewBookContainer(b);
            }
        }

        private string getSelectedGenre()
        {
            foreach (Control control in PNcategory.Controls)
            {
                if (control is HtmlGenericControl div)
                {
                    foreach (Control childControl in div.Controls)
                    {
                        if (childControl is RadioButton radioButton && radioButton.GroupName == "categoryItem" && radioButton.Checked)
                        {
                            return radioButton.Text;
                        }
                    }
                }
            }
            return null;
        }

        private void addCategory()
        {
            List<string> genres = homeCon.getGenres();

            foreach(string g in genres)
            {
                addCategoryRB(g);
            }
        }

        private void addCategoryRB(string g)
        {
            HtmlGenericControl div = homeCon.addCategoryRB(g);
            PNcategory.Controls.Add(div);
        }

        private void addViewBook()
        {
            string text = Request.QueryString["text"];

            List<Book> books = null;

            if (String.IsNullOrEmpty(text))
            {
                books = homeCon.getAllBooks();
            }
            else
            {
                books = homeCon.getAllBooks(text);
            }
              



            foreach(var b in books)
            {
                addViewBookContainer(b);
            }
        }

        private void addViewBookContainer(Book b)
        {
            LinkButton button = homeCon.addViewBook(b);
            button.CommandArgument = b.Id.ToString();
            button.Command += new CommandEventHandler(ViewBook_Command);
            PNcontainerShowItem.Controls.Add(button);
        }

        protected void ViewBook_Command(object sender, CommandEventArgs e)
        {
            string bookId = e.CommandArgument.ToString();
            Response.Redirect($"ViewItem.aspx?BookId={bookId}");
        }

    }
}