import { UserAccount } from "./user-account";

export class Address {
    addressId: number;
    customerName: string;
    unitStreet: string;
    city: string;
    state: string;
    zipcode: string;
    accountId: number;
    user: UserAccount;
}
