export interface ICredential {
  email: string;
  password: string;
}

export class Credential implements ICredential {
  public email: string;
  public password: string;
}
