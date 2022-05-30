using gullycricket.DB;
using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace gullycricket.Services
{
    public class UserManagment
    {
        public void BindUserType(DropDownList oList)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUserTypes = eDataBase.UserTypes.ToList();
                    oList.DataSource = eUserTypes;
                    oList.DataTextField = "UserTypeName";
                    oList.DataValueField = "Id";
                    oList.DataBind();
                    oList.Items.Insert(0, new ListItem("Select User type", "0"));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void SignUpUser(UserInfo oInfo)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var record = eDataBase.Users.Where(eUData => eUData.LoginId == oInfo.LoginId || eUData.Email == oInfo.Email).FirstOrDefault();
                    if(record != null)
                    {
                        if(record.LoginId == oInfo.LoginId)
                        {
                            throw new Exception("User with the same login ID already exisits. Please try another login ID");
                        }
                        else if(record.Email == oInfo.Email)
                        {
                            throw new Exception("User with the same Email already exisits. Please try another Email");
                        }
                    }

                    


                    User eUser = new User();
                    eUser.Name = oInfo.Name;
                    eUser.Email = oInfo.Email;
                    eUser.LoginId = oInfo.LoginId;
                    eUser.Password = oInfo.Password;
                    eUser.UserTypeId = oInfo.UserTypeId;
                    eUser.IsVerified = false;
                    eUser.RegisteredOn = DateTime.Now;
                    eDataBase.Users.InsertOnSubmit(eUser);
                    eDataBase.SubmitChanges();
                    eUser.PlayerId = DateTime.Now.Year + "-" + eUser.Id;
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void SignInUser(UserInfo oInfo)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var record = eDataBase.Users.Where(eUData => eUData.LoginId == oInfo.LoginId && eUData.Password == oInfo.Password).FirstOrDefault();
                    if (record == null)
                    {
                        throw new Exception("Invalid Login ID or Password");
                    }
                    if(record.IsVerified == false)
                    {
                        throw new Exception("Your account is not verified yet!");
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}