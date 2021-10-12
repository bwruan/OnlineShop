export class UpdateAddressRequest {
    addressId: number;
    newCustomer: string;
    newUnitStreet: string;
    newCity: string;
    newState: string;
    newZipcode: string;

    constructor(addressId: number, newCustomer: string, newUnitStreet: string, newCity: string,
        newState: string, newZipcode: string){
        this.addressId = addressId;
        this.newCustomer = newCustomer;
        this.newUnitStreet = newUnitStreet;
        this.newCity = newCity;
        this.newState = newState;
        this.newZipcode = newZipcode;
    }
}
