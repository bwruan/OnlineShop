export class AddPaymentRequest {
    paymentId: number;
    nameOnCard: string;
    cardNumber: string;
    securityCode: string;
    expDate: string;
    cardTypeId: number;
    accountId: number;

    constructor(paymentId: number, nameOnCard: string, cardNumber: string, securityCode: string, expDate: string, cardTypeId: number, accountId: number){
        this.paymentId = paymentId;
        this.nameOnCard = nameOnCard;
        this.cardNumber = cardNumber;
        this.securityCode = securityCode;
        this.expDate = expDate;
        this.cardTypeId = cardTypeId;
        this.accountId = accountId;
    }
}
