export class AddToCartRequest {
    itemId: number;
    amount: number;
    accountId: number;

    constructor(itemId: number, amount: number, accountId: number){
        this.itemId = itemId;
        this.amount =amount;
        this.accountId = accountId;
    }
}
