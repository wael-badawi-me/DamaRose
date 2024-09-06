using Dama.POS.DAL.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleAdmin.Model;
public class UserModel
{
    private User user;
    public UserModel()
    {
        user = new User();
    }
    public UserModel(User initUser)
    {
        user = initUser;
    }
    [JsonIgnore]
    public User DBUser
    {
        get {return user; }
    }
    public string id
    {
        get { return user.Id; }
    }
    [Required]
    public string name
    {
        get { return user.Name; }
        set { user.Edit(value, user.IsEnabled); }
    }
    //[Required]
    //[EmailAddress]
    //public string email
    //{
    //    get { return user.Email; }
    //    set { user.Email = value; }
    //}
    [Required]
    public string password
    {
        get { return user.Password; }
    }
    public string description
    {
        get { return user.Description; }
    }
    public DateTime createdDate
    {
        get { return user.CreatedDate; }
    }
    public DateTime lastModifiedDate
    {
        get { return user.LastModifiedDate; }
    }
    [Required]
    public bool isEnabled
    {
        get { return user.IsEnabled; }
        set { user.Edit(user.Name, value); }

    }
}
