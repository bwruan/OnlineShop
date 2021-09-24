export class UpdateAddressRequest {
    addressId: number;
    newShipping: string;

    constructor(addressId: number, newShipping: string){
        this.addressId = addressId;
        this.newShipping = newShipping;
    }
}
