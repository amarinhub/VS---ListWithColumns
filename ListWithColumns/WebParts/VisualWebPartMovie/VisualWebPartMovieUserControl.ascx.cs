using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

namespace ListWithColumns.WebParts.VisualWebPartMovie
{
    public partial class VisualWebPartMovieUserControl : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            SPList movies = SPContext.Current.Web.Lists.TryGetList("Movies");

            SPListItemCollection moviesCollection = movies.Items;

            RepeaterMovie.DataSource = moviesCollection;
            RepeaterMovie.DataBind();

        }

        // NOT IN USE 
        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SPList movies = SPContext.Current.Web.Lists.TryGetList("Movies");

            SPListItemCollection moviesCollection = movies.Items;

            int movieItemId = int.Parse(((LinkButton)e.Item.FindControl("RemoveButton")).CommandArgument);

            LinkButton click =(LinkButton)e.Item.FindControl("RemoveButton");

            click.Attributes.Add("OnClick", "showDialog()");

            if (e.CommandName == "delete")
            {
                moviesCollection.DeleteItemById(movieItemId);
            }
            //else if (e.CommandName == "edit")
            //{
            //    EditIndex = e.Item.ItemIndex;
            //}
            //else if (e.CommandName == "save")
            //{
            //    HtmlInputHidden t = e.Item.FindControl("firstNameHidden") as HtmlInputHidden;
            //    Data.Contacts[e.Item.ItemIndex].FirstName = t.Value;
            //    t = e.Item.FindControl("lastNameHidden") as HtmlInputHidden;
            //    Data.Contacts[e.Item.ItemIndex].LastName = t.Value;
            //    EditIndex = -1;
            //}

            RepeaterMovie.DataSource = moviesCollection;
            RepeaterMovie.DataBind();
        }

        // Update Item value(s)
        protected void TextBox_OnTextChanged(object sender, EventArgs e)
        {
            // Text BOX where i changed/write smth.
            TextBox txtBox = ((TextBox)(sender));
            // Find the origine of repeater
            RepeaterItem repeater = (RepeaterItem)(txtBox.NamingContainer);

            // What is written now inside Text Box;
            string valueTxtBox = txtBox.Text.Trim();

            // What TxtBox is ? txtMovie_Name => remove first 3chars => Movie_Name
            string idTxtBox = txtBox.ID.ToString().Trim();
            // get the name of the Field => txtMovie_Name - 3chars => Movie_Name 
            idTxtBox = idTxtBox.Remove(0, 3);

            // Get Id of the row in the list
            Label txtID = (Label)repeater.FindControl("lbl_Id");
            

            SPList movies = SPContext.Current.Web.Lists.TryGetList("Movies");
            SPItem item = movies.GetItemById(int.Parse(txtID.Text));

            item[idTxtBox] = valueTxtBox;

            item.Update();


          //  this.BindRepeater();

        }

        protected void OnEdit(object sender, EventArgs e)

        {

            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            int index = item.ItemIndex;

            this.ToggleElements(item, true);

        }

        // On Click Update => 
        protected void OnUpdate(object sender, EventArgs e)

        {

            //Find the reference of the Repeater Item.

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            int itemId = int.Parse((item.FindControl("lbl_ID") as Label).Text);

            

            string name = (item.FindControl("txtMovie_Name") as TextBox).Text.Trim();
            TextBox nameTxtBox = (item.FindControl("txtMovie_Name") as TextBox);
            TextBox_OnTextChanged(nameTxtBox, e);

            string category = (item.FindControl("txtMovie_Category") as TextBox).Text.Trim();
            TextBox categoryTxtBox = (item.FindControl("txtMovie_Category") as TextBox);
            TextBox_OnTextChanged(categoryTxtBox, e);

            string description = (item.FindControl("txtMovie_Description") as TextBox).Text.Trim();
            TextBox descriptionTxtBox = (item.FindControl("txtMovie_Description") as TextBox);
            TextBox_OnTextChanged(descriptionTxtBox, e);


            string year = (item.FindControl("txtMovie_Year") as TextBox).Text.Trim();
            TextBox yearTxtBox = (item.FindControl("txtMovie_Year") as TextBox);
            TextBox_OnTextChanged(yearTxtBox, e);

            string price = (item.FindControl("txtMovie_Price") as TextBox).Text.Trim();
            TextBox priceTxtBox = (item.FindControl("txtMovie_Price") as TextBox);
            TextBox_OnTextChanged(priceTxtBox, e);

            this.ToggleElements(item, false);

            this.BindRepeater();

        }

        // add New Item to List
        protected void addItem(object sender, EventArgs e)

        {

            string name = productName.Value;
            string category = productCategory.Value;
            string description = productDescription.Value;
            string year = productYear.Value;
            string price = productPrice.Value;

            SPList list = SPContext.Current.Web.Lists.TryGetList("Movies");
            SPListItemCollection listItems = list.Items;
            
            // Create new item in the list
            SPListItem item = listItems.Add();

            item["Movie_Name"] =name;
            item["Movie_Category"] = category;
            item["Movie_Year"] = Convert.ToInt32(year);
            item["Movie_Price"] = Convert.ToInt32(price);

            item.Update();

            // Clear input boxes
            productName.Value = "";
            productCategory.Value = "";
            productDescription.Value = "";
            productYear.Value = "";
            productPrice.Value = "";

            this.BindRepeater();

        //  MessageBox.Show("Success", "Add new  item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }


        protected void OnDelete(object sender, EventArgs e)

        {

            //Find the reference of the Repeater Item.

            RepeaterItem repeater = (sender as LinkButton).Parent as RepeaterItem;

            int itemId = int.Parse((repeater.FindControl("lbl_ID") as Label).Text);

            string name = (repeater.FindControl("txtMovie_Name") as TextBox).Text.Trim();

            string category = (repeater.FindControl("txtMovie_Category") as TextBox).Text.Trim();
            
            // get name of the List
            SPList list = SPContext.Current.Web.Lists.TryGetList("Movies");
            
            // get all the 'rows'
            SPListItemCollection items = list.Items;
            // SPItem items = list.GetItemById(itemId);

            foreach (SPListItem item in items)
            {
                object row = item["Movie_Name"];
                if ( row.ToString() == name)
                {
                    item.Delete();
                    break;
                }
            }

            //Delete the first item
            //list.Items[itemId].Delete();
            //Update the first item
            //Note the use of a temporary SPListItem
            //SPListItem updateItem = list.Items[itemId];
            //updateItem.Update();
            //list.Update();

            this.BindRepeater();

        }

        protected void OnCancel(object sender, EventArgs e)

        {

            //Find the reference of the Repeater Item.

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            this.ToggleElements(item, false);

        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("lnkEdit").Visible = !isEdit;
            item.FindControl("lnkUpdate").Visible = isEdit;
            item.FindControl("lnkCancel").Visible = isEdit;
            item.FindControl("lnkDelete").Visible = !isEdit;

            //Toggle Labels.
            item.FindControl("lblMovie_Name").Visible = !isEdit;
            item.FindControl("lblMovie_Category").Visible = !isEdit;
            item.FindControl("lblMovie_Description").Visible = !isEdit;
            item.FindControl("lblMovie_Year").Visible = !isEdit;
            item.FindControl("lblMovie_Price").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtMovie_Name").Visible = isEdit;
            item.FindControl("txtMovie_Category").Visible = isEdit;
            item.FindControl("txtMovie_Description").Visible = isEdit;
            item.FindControl("txtMovie_Year").Visible = isEdit;
            item.FindControl("txtMovie_Price").Visible = isEdit;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}
