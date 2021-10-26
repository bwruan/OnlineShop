export class PaymentRequest {
    paymentId: number;
    nameOnCard: string;
    cardNumber: string;
    securityCode: string;
    expDate: Date;
    billingName: string;
    billingUnit: string;
    billingCity: string;
    billingState: string;
    billingZipcode: string;
    cardType: number;
    accountId: number;

    constructor(paymentId: number, nameOnCard: string, cardNumber: string, securityCode: string, expDate: Date, billingName: string, billingUnit: string, 
        billingCity: string, billingState: string, billingZipcode: string, cardType: number, accountId: number){
        this.paymentId = paymentId;
        this.nameOnCard = nameOnCard;
        this.cardNumber = cardNumber;
        this.securityCode = securityCode;
        this.expDate = expDate;
        this.billingName = billingName;
        this.billingUnit = billingUnit;
        this.billingCity = billingCity;
        this.billingState = billingState;
        this.billingZipcode = billingZipcode;
        this.cardType = cardType;
        this.accountId = accountId;
    }
}
