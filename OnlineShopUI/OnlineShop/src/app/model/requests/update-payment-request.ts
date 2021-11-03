export class UpdatePaymentRequest {
    paymentId: number;
    newNameOnCard: string;
    newCardNumber: string;
    newSecurityCode: string;
    newExpDate: string;
    newCardTypeId: number;

    constructor(paymentId: number, newNameOnCard: string, newCardNumber: string, newSecurityCode: string, newExpDate: string, newCardTypeId: number){
        this.paymentId = paymentId;
        this.newNameOnCard = newNameOnCard;
        this.newCardNumber = newCardNumber;
        this.newSecurityCode = newSecurityCode;
        this.newExpDate = newExpDate;
        this.newCardTypeId = newCardTypeId;
    }
}
