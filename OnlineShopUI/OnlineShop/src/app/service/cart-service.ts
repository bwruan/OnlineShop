import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Cart } from "../model/cart";
import { AddToCartRequest } from "../model/requests/add-to-cart-request";

@Injectable({
    providedIn: 'root'
})

export class CartService {
    baseUrl: string = environment.shoppingApi;

    constructor(private _http: HttpClient){}

    addToCart(addItem: AddToCartRequest): Observable<any>{
        return this._http.post(this.baseUrl + "/cart/addToCart", addItem);
    }

    getItemsInCart(): Observable<Cart[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        return this._http.get<Cart[]>(this.baseUrl + "/cart/cartItems/", {headers: header});
    }

    purchaseRemove(){
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.delete(this.baseUrl + "/cart/emptyCart/", {headers: header});
    } 
}
