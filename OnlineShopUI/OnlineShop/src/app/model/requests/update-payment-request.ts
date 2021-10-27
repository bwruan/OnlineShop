export class UpdatePaymentRequest {
    paymentId: number;
    newNameOnCard: string;
    newCardNumber: string;
    newSecurityCode: string;
    newExpDate: string;
    newBillingName: string;
    newBillingUnit: string;
    newBillingCity: string;
    newBillingState: string;
    newBillingZipcode: string;
    newCardType: number;

    constructor(paymentId: number, newNameOnCard: string, newCardNumber: string, newSecurityCode: string, newExpDate: string, newBillingName: string, newBillingUnit: string, 
        newBillingCity: string, newBillingState: string, newBillingZipcode: string, newCardType: number){
        this.paymentId = paymentId;
        this.newNameOnCard = newNameOnCard;
        this.newCardNumber = newCardNumber;
        this.newSecurityCode = newSecurityCode;
        this.newExpDate = newExpDate;
        this.newBillingName = newBillingName;
        this.newBillingUnit = newBillingUnit;
        this.newBillingCity = newBillingCity;
        this.newBillingState = newBillingState;
        this.newBillingZipcode = newBillingZipcode;
        this.newCardType = newCardType;
    }
}
