using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "The category has been added to DB.";
        public static string CategoryDeleted = "The category has been deleted to DB.";
        public static string CategoryListed = "Categories listed.";
        public static string CategoryUpdated = "The category has been updated to DB.";

        public static string BrandAdded = "The brand has been added to DB.";
        public static string BrandDeleted = "The brand has been deleted to DB.";
        public static string BrandListed = "Brands listed.";
        public static string BrandUpdated = "The brand has been updated to DB.";

        public static string ConditionAdded = "The condition has been added to DB.";
        public static string ConditionDeleted = "The condition has been deleted to DB.";
        public static string ConditionListed = "Conditions listed.";
        public static string ConditionUpdated = "The condition has been updated to DB.";

        public static string UserAdded = "The user has been added to DB.";
        public static string UserDeleted = "The user has been deleted to DB.";
        public static string UserListed = "Users listed.";
        public static string UserUpdated = "The user has been updated to DB.";
        public static string UserDetails = "User details listed";

        public static string DonationAdded = "The donation has been added to DB.";
        public static string DonationDeleted = "The donation has been deleted to DB.";
        public static string DonationListed = "Donations listed.";
        public static string DonationUpdated = "The donation has been updated to DB.";

        public static string ProductAdded = "The product has been added to DB.";
        public static string ProductDeleted = "The product has been deleted to DB.";
        public static string ProductListed = "Products listed.";
        public static string ProductUpdated = "The product has been updated to DB.";

        public static string ProductImageAdded = "The product images has been added to DB.";
        public static string ProductImageDeleted = "The product images has been deleted to DB.";
        public static string ProductImageUpdated = "The product images has been updated to DB.";
        public static string ImageAddingLimit = "You can add 5 photos";

        public static string AuthorizationDenied = "You are not authorized";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Wrong password!";
        public static string SuccessfulLogin = "Signed in";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";
    }
}
