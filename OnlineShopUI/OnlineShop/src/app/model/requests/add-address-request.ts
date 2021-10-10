export class AddAddressRequest {
    addressId: number;
    customerName: string;
    unitStreet: string;
    city: string;
    state: string;
    zipcode: string;
    accountId: number;

    constructor(addressId: number, customerName: string, unitStreet: string, city: string,
        state: string, zipcode: string, accountId: number){
        this.addressId = addressId;
        this.customerName = customerName;
        this.unitStreet = unitStreet;
        this.city = city;
        this.state = state;
        this.zipcode = zipcode;
        this.accountId = accountId;
    }
}
