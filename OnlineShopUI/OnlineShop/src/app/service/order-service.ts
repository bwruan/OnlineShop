import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Order } from "../model/order";
import { PurchaseOrderRequest } from "../model/requests/purchase-order-request";

@Injectable({
    providedIn: 'root'
})

export class OrderService {
    baseUrl: string = environment.shoppingApi;

    constructor(private _http: HttpClient){}

    getOrdersByAccountId(): Observable<Order[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        let accountId = Number(localStorage.getItem("accountId"));
        
        return this._http.get<Order[]>(this.baseUrl + "/order/account/" + accountId, {headers: header});
    }

    getOrdersByOrderNum(orderNum: number): Observable<Order[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Order[]>(this.baseUrl + "/order/orderNum?orderNum=" + orderNum, {headers: header});
    }

    purchaseOrder(newOrder: PurchaseOrderRequest){
        return this._http.post(this.baseUrl + "/order/purchase",newOrder);
    }
}
