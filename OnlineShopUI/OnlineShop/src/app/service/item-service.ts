import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Item } from "../model/item";

@Injectable({
    providedIn: 'root'
})

export class ItemService {
    baseUrl: string = environment.shoppingApi;

    constructor(private _http: HttpClient){}

    getAllItems(): Observable<Item[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Item[]>(this.baseUrl + "/item/allItems/", {headers: header});
    }

    getItemByItemId(itemId: number): Observable<Item>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Item>(this.baseUrl + "/item/item/" + itemId, {headers: header});
    }

    getItemsByItemType(itemTypeId: number): Observable<Item[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Item[]>(this.baseUrl + "/item/itemType/" + itemTypeId, {headers: header});
    }
}
