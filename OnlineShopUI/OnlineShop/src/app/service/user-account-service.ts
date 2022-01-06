import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { AddAccountRequest } from "../model/requests/add-account-request";
import { LoginRequest } from "../model/requests/login-request";
import { UpdateAccountRequest } from "../model/requests/update-account-request";
import { UserAccount } from "../model/user-account";

@Injectable({
    providedIn: 'root'
})

export class UserAccountService {
    baseUrl: string = environment.accountApi;

    constructor(private _http: HttpClient){}

    addAccount(newAccount: AddAccountRequest): Observable<any>{
        return this._http.post(this.baseUrl + "/userAccount/addAccount", newAccount);
    }

    logIn(loginObj: LoginRequest): Observable<any>{
        return this._http.patch(this.baseUrl + "/userAccount/login", loginObj);
    }

    logOut(): Observable<any>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        let accountId = Number(localStorage.getItem("accountId"));
        
        return this._http.patch(this.baseUrl + "/userAccount/logout/" + accountId, {headers: header});
    }

    getAccountByEmail(): Observable<UserAccount>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        let email = localStorage.getItem("email");
        return this._http.get<UserAccount>(this.baseUrl + "/userAccount?email=" + email, {headers: header});
    }

    getAccountById(): Observable<UserAccount>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });

        let id = localStorage.getItem("accountId");
        return this._http.get<UserAccount>(this.baseUrl + "/userAccount/" + id, {headers: header});
    }

    updateAccount(updateObj: UpdateAccountRequest): Observable<any>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.put(this.baseUrl + "/userAccount/updateAccount", updateObj, {headers: header});
    }
}
