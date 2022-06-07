using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using UserDetailsApp.Authorization;
using UserDetailsApp.Entities;
using UserDetailsApp.Helpers;
using UserDetailsApp.Models.Users;

namespace UserDetailsApp.Services
{
    public interface IUserService
    {
        AuthenticateResponse Login(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        GetUserDetails GetByEmail(string email);
        void Register(RegisterRequest model);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse? Login(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Email or password is incorrect");
            
            //// authentication successful
            //var response = _mapper.Map<AuthenticateResponse>(user);
            //response.Token = _jwtUtils.GenerateToken(user);
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already exist");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        private User GetUserbyMailId(string email)
        {
            var user = _context.Users.Where(u => u.Email == email);
            if (user == null) throw new KeyNotFoundException("User not found");
            return (User)user;
        }

        public GetUserDetails GetByEmail(string email)
        {
            var user = GetUserbyMailId(email);
            var uModel = new GetUserDetails();

            if (user != null)
            {
                uModel = new GetUserDetails
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNo = user.PhoneNo,
                };
            }
            return uModel;
        }
    }
}