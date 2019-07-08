import { Guid } from 'guid-typescript';

export interface IAuthenticationResponse {

  name: string;
  accessToken: string;
  email: string;
  userName: string;
  userAccountId: Guid;
}


export class AuthenticationResponse implements IAuthenticationResponse {
  public name: string;
  public accessToken: string;
  public email: string;
  public userName: string;
  public userAccountId: Guid;
}
