export class AddAddressRequest {
    addressId: number;
    shipping: string;
    accountId: number;

    constructor(addressId: number, shipping: string, accountId: number){
        this.addressId = addressId;
        this.shipping = shipping;
        this.accountId = accountId;
    }
}
