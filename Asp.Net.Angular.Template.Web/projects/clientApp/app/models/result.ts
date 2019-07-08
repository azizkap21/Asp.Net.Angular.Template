
export class Result {
    message: string;
    detailedError: string;
    errorCode: StatusCode;
}


export enum StatusCode {
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    NotAcceptable = 406,
    TimeOut = 408,
    InternalServerError = 500,
    BadGateway = 502,
    ServiceUnavailable = 503,
    NetworkTimeout = 511,

    WrongCredential = 801,

    //Db errors
    NotExist = 600,
    UniqueConstrainError = 601,
    ForeignKeyViolation = 602,

    UnknownError = 999,
}
