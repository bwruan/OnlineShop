import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Address } from "../model/address";
import { AddAddressRequest } from "../model/requests/add-address-request";
import { UpdateAddressRequest } from "../model/requests/update-address-request";

@Injectable({
    providedIn: 'root'
})

export class AddressService {
    baseUrl: string = environment.addressApi;

    constructor(private _http: HttpClient){}

    addAddress(newAddress: AddAddressRequest): Observable<any>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        return this._http.post(this.baseUrl + "/address/addAddress", newAddress, {headers: header});
    }

    getAddressesByAccountId(): Observable<Address[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        let accountId = Number(localStorage.getItem("accountId"));
        return this._http.get<Address[]>(this.baseUrl + "/address/addressList/" + accountId, {headers: header});
    }

    getAddressByAddressId(addressId: number): Observable<Address>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Address>(this.baseUrl + "/address/get/" + addressId, {headers: header});
    }

    updateAddress(updateObj: UpdateAddressRequest): Observable<any>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.put(this.baseUrl + "/address/updateAddress", updateObj, {headers: header});
    }

    deleteAddress(addressId: number){
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.delete(this.baseUrl + "/address/deleteAddress/" + addressId, {headers: header});
    }
}
