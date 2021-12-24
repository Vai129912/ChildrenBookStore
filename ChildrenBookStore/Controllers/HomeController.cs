using ChildrenBookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserDetails()
        {
            return View();
        }
        public IActionResult cart1()
        {

            return View();

        }
        [HttpPost]
        public IActionResult UserDetails(UserDetails user)
        {

            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into UserDetails (userdetails_name,userdetais_email,userdetails_address,userdetails_state,userdetails_pincode) Values ('{user.UserDetails_name}', '{user.UserDetails_email}','{user.UserDetails_address}','{user.UserDetails_pincode}','{user.UserDetails_pincode}' )";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Sucess");
        }
        public IActionResult LoginSignupPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSignupPage(Registration registration)
        {

            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Register (name, email, password) Values ('{registration.Name}', '{registration.Email}','{registration.Password}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            ViewBag.Result = 1;
            return View();
        }
        public IActionResult Login(Registration register)
        {

            var check = 1;
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select Email,Password From Register where email = '{register.LoginEmail}' and password = '{register.LoginPassword}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    var validate = command.ExecuteScalar();
                    if (validate != null)
                    {
                        check = 0;

                    }
                    connection.Close();
                }

            }
            if (check == 0)
            {

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Query = 1;
            }

            return RedirectToAction("LoginSignupPage");

        }
        public IActionResult ActivityBooks()
        {
            return View();
        }
        public IActionResult WordSearchBook()
        {
            return View();
        }
        public IActionResult NumberConnectingBook()
        {
            return View();
        }
        public IActionResult SubjectBooks()
        {
            return View();
        }
        public IActionResult RhymesBook()
        {
            return View();
        }
        public IActionResult MathBook()
        {
            return View();
        }
        public IActionResult StoryBooks()
        {
            return View();
        }
        public IActionResult Panchatanthrabook()
        {
            return View();
        }
        public IActionResult Sucess()
        {
            List<UserDetails> UserList = new List<UserDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From UserDetails";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        UserDetails user = new UserDetails();
                        user.UserDetails_id = Convert.ToInt32(dataReader["userdetails_id"]);
                        user.UserDetails_name = Convert.ToString(dataReader["Name"]);
                        user.UserDetails_email = Convert.ToString(dataReader["Email"]);
                        user.UserDetails_address = Convert.ToString(dataReader["Address"]);
                        user.UserDetails_state = Convert.ToString(dataReader["State"]);
                        user.UserDetails_pincode = Convert.ToInt32(dataReader["Pincode"]);
                        UserList.Add(user);
                    }
                }
                connection.Close();

            }
            return View(UserList);
        }
        //[Route]
        public IActionResult Cart1()
        {
            return View();
        }
        public IActionResult Display()
        {
            List<ChildBookDetail> UserList = new List<ChildBookDetail>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDisplay where Product_Id = '7'";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ChildBookDetail user = new ChildBookDetail();
                        user.book_id = Convert.ToInt32(dataReader["book_id"]);
                        user.book_name = Convert.ToString(dataReader["book_name"]);
                        user.category_name = Convert.ToString(dataReader["category_name"]);
                        user.book_authorname = Convert.ToString(dataReader["book_authorname"]);
                        user.book_price = Convert.ToInt32(dataReader["book_price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        UserList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["book_id"]);
                    }
                }
                connection.Close();

            }

            return View(UserList);
        }
        public IActionResult Cart()
        {
            List<ChildBookDetail> CartList = new List<ChildBookDetail>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDisplay p, Cart c where c.Id = p.Product_Id";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ChildBookDetail user = new ChildBookDetail();
                        user.book_id = Convert.ToInt32(dataReader["book_Id"]);
                        user.book_name = Convert.ToString(dataReader["book_name"]);
                        user.category_name = Convert.ToString(dataReader["category_name"]);
                        user.book_authorname = Convert.ToString(dataReader["book_authorname"]);
                        user.book_price = Convert.ToInt32(dataReader["book_price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        CartList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["book_id"]);
                    }
                }
                connection.Close();

            }

            return View(CartList);

        }
        [HttpPost]
        public IActionResult Cartinsert(int id)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Cart(Id) Values ('{id}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return View();
        }
        public IActionResult ProductDisplay()
        {
            List<ChildBook> products = new List<ChildBook>() {
                new ChildBook () {
                    book_id = 1,
                    Photo ="https://images-na.ssl-images-amazon.com/images/I/91wlN6PrfDL.jpg",
                    book_name = "Panchatantra",
                    book_price = 315,
                    book_authorname= "Om Books Team",
                    Description="The Panchatantra is the oldest collection of Indian fables. Most of the characters are animals, with a typical nature, like the lion is strong but dull, the rabbit is wise, the Jackal is clever, the tortoise is silly and the cat is cunning."
                },
            };
            ViewBag.products = products;
            return View();
        }

    }
}