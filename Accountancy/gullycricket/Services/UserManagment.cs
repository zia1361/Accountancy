using gullycricket.DB;
using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace gullycricket.Services
{
    public class UserManagment
    {

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
                    eUser.UserName = oInfo.Name;
                    eUser.Email = oInfo.Email;
                    eUser.LoginId = oInfo.LoginId;
                    eUser.Password = oInfo.Password;
                    eUser.IsVerified = false;
                    eUser.RegisteredOn = DateTime.Now;
                    eDataBase.Users.InsertOnSubmit(eUser);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public AuthenticationModel SignInUser(UserInfo oInfo)
        {
            try
            {
                AuthenticationModel authenticationModel = new AuthenticationModel();
                authenticationModel.Authenticated = false;
                UserInfo oUser = new UserInfo();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUser = eDataBase.Users.Where(eUData => eUData.LoginId == oInfo.LoginId && eUData.Password == oInfo.Password).FirstOrDefault();
                    if (eUser == null)
                    {
                        throw new Exception("Invalid Login ID or Password");
                    }
                    if(eUser.IsVerified == false)
                    {
                        throw new Exception("Your account is not verified yet!");
                    }
                    oUser.Id = eUser.Id;
                    oUser.Name = eUser.UserName;
                    oUser.Email = eUser.Email;
                    oUser.IsVerified = eUser.IsVerified;
                    oUser.Password = eUser.Password;
                    oUser.LoginId = eUser.LoginId;
                    oUser.ImageURL = eUser.ImageURL != null && eUser.ImageURL != "" ? 
                        (ConfigurationManager.AppSettings["BaseURL"] + "PROFILEIMAGES/" + eUser.ImageURL) : "../assets/assets/img/profile-img.jpg";
                    oUser.RegisteredOnDate = eUser.RegisteredOn;
                    oUser.RegisteredOnDateString = eUser.RegisteredOn.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                    authenticationModel.oUser = oUser;
                    authenticationModel.Authenticated = eUser != null;
                    SessionService.Save(SessionService.Keys.AuthenticationInfo, authenticationModel);

                    return authenticationModel;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UserInfo GetUserById(int userId)
        {
            try
            {
                UserInfo oUser = new UserInfo();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUser = eDataBase.Users.Where(eUdata => eUdata.Id == userId).FirstOrDefault();
                    if (eUser == null)
                    {
                        throw new Exception("Invalid Login ID or Password");
                    }
                    if (eUser.IsVerified == false)
                    {
                        throw new Exception("Your account is not verified yet!");
                    }
                    oUser.Id = userId;
                    oUser.Name = eUser.UserName;
                    oUser.Email = eUser.Email;
                    oUser.IsVerified = eUser.IsVerified;
                    oUser.Password = eUser.Password;
                    oUser.LoginId = eUser.LoginId;
                    oUser.ImageURL = eUser.ImageURL != null && eUser.ImageURL != "" ?
                        (ConfigurationManager.AppSettings["BaseURL"] + "PROFILEIMAGES/" + eUser.ImageURL) : "../assets/assets/img/profile-img.jpg";
                    oUser.RegisteredOnDate = eUser.RegisteredOn;
                    oUser.RegisteredOnDateString = eUser.RegisteredOn.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                }
                return oUser;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(UserInfo oUser)
        {
            try
            {
                AuthenticationModel authenticationModel = new AuthenticationModel();
                authenticationModel.Authenticated = false;
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUser = eDataBase.Users.Where(eUdata => eUdata.Id == oUser.Id).FirstOrDefault();
                    if (eUser == null)
                    {
                        throw new Exception("Invalid Login ID or Password");
                    }
                    if (eUser.IsVerified == false)
                    {
                        throw new Exception("Your account is not verified yet!");
                    }

                    var record = eDataBase.Users.Where(eUData => (eUData.LoginId == oUser.LoginId || eUData.Email == oUser.Email) &
                                eUData.Id != oUser.Id).FirstOrDefault();
                    if (record != null)
                    {
                        if (record.LoginId == oUser.LoginId )
                        {
                            throw new Exception("User with the same login ID already exisits. Please try another login ID");
                        }
                        if (record.Email == oUser.Email)
                        {
                            throw new Exception("User with the same Email already exisits. Please try another Email");
                        }
                    }

                    eUser.UserName = oUser.Name;
                    eUser.Email = oUser.Email;
                    eUser.LoginId = oUser.LoginId;
                    if(oUser.ImageURL != null && oUser.ImageURL != "")
                    {
                        eUser.ImageURL = oUser.ImageURL;
                        oUser.ImageURL = ConfigurationManager.AppSettings["BaseURL"] + "PROFILEIMAGES/" + oUser.ImageURL;
                    }
                    else
                    {
                        oUser.ImageURL =  "../assets/assets/img/profile-img.jpg";
                    }
                    eDataBase.SubmitChanges();
                    oUser.Id = eUser.Id;
                    oUser.IsVerified = eUser.IsVerified;
                    oUser.Password = eUser.Password;
                    oUser.RegisteredOnDate = eUser.RegisteredOn;
                    oUser.RegisteredOnDateString = eUser.RegisteredOn.ToString(ConfigurationManager.AppSettings["DateFormat"]);

                    authenticationModel.oUser = oUser;

                    

                    authenticationModel.Authenticated = eUser != null;
                    SessionService.Save(SessionService.Keys.AuthenticationInfo, authenticationModel);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdatePasswordByUserId(int userId, string password)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUser = eDataBase.Users.Where(eUdata => eUdata.Id == userId).FirstOrDefault();
                    if (eUser == null)
                    {
                        throw new Exception("Invalid or no login Id found");
                    }
                    eUser.Password = password;
                    eDataBase.SubmitChanges();
                    var authenticationModel = SessionService.GetCurrentUser();
                    authenticationModel.oUser.Password = password;
                    SessionService.Save(SessionService.Keys.AuthenticationInfo, authenticationModel);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void BindUsers(DropDownList gList)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eUsers = eDataBase.Users.Where(eUData => eUData.IsVerified == true).ToList();
                    gList.DataSource = eUsers;
                    gList.DataTextField = "Name";
                    gList.DataValueField = "Id";
                    gList.DataBind();
                    gList.Items.Insert(0, new ListItem("Select User", "0"));
                }
            }
            catch (Exception ex)
            {

                throw new Exception( ex.Message);
            }
        }
    }
}