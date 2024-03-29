﻿namespace AnimalAdoption.BusinessLogic.Exceptions
{
    public enum ErrorCode
    {
        UserAlreadyExist = 1,
        SomethingWentWrong,
        AddUserPreferencesException,
        AddUserException,
        InvalidUsernameOrPassword,
        AddAnimalFailed,
        InvalidEmailAddress,
        InvalidPassword,
        AnnouncementWithRequests,
        UserEmailAlreadyExists
    }
}
