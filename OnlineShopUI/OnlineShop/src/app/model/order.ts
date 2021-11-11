import { Item } from "./item";

export class Order {
    orderId: number;
    orderNum: number;
    purchaseDate: Date;
    accountId: number;
    itemId: number;
    orderedItem: Item;
}
