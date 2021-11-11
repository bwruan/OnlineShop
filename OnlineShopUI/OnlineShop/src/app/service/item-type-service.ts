import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ItemType } from "../model/item-type";

@Injectable({
    providedIn: 'root'
})

export class ItemTypeService {
    baseUrl: string = environment.shoppingApi;

    constructor(private _http: HttpClient){}

    getItemType(): Observable<ItemType[]>{
        return this._http.get<ItemType[]>(this.baseUrl + "/itemType/itemType");
    }
}