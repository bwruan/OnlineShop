import { UserAccount } from "./user-account";

export class Address {
    addressId: number;
    shipping: string;
    accountId: number;
    user: UserAccount;
}
