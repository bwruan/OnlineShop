import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { CardType } from "../model/card-type";

@Injectable({
    providedIn: 'root'
})

export class CardTypeService {
    baseUrl: string = environment.paymentApi;

    constructor(private _http: HttpClient){}

    getCardTypes(): Observable<CardType[]>{
        return this._http.get<CardType[]>(this.baseUrl + "card/cardType");
    }
}
