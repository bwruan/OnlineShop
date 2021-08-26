export class UpdateAccountRequest {
    accountId: number;
    newName: string;
    newEmail: string;
    newPassword: string;

    constructor(accountId: number, newName: string, newEmail: string, newPassword: string){
        this.accountId = accountId;
        this.newName = newName;
        this.newEmail = newEmail;
        this.newPassword = newPassword;
    }
}
