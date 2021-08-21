export class AddAccountRequest {
    accountId: number;
    name: string;
    email: string;
    password: string;

    constructor(accountId: number, name: string, email: string, password: string){
        this.accountId = accountId;
        this.name = name;
        this.email = email;
        this.password = password;
    }
}
