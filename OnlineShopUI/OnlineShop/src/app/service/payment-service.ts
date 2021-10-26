import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Payment } from "../model/payment";
import { UpdatePaymentRequest } from "../model/requests/update-payment-request";

@Injectable({
    providedIn: 'root'
})

export default class PaymentService {
    baseUrl: string = environment.paymentApi;

    constructor(private _http: HttpClient){}

    addPayment(newPayment: PaymentRequest): Observable<any>{
        return this._http.post(this.baseUrl + "/payment/addPayment", newPayment);
    }

    getPaymentByPaymentId(paymentId: number): Observable<Payment>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.get<Payment>(this.baseUrl + "/payment/getPayment/" + paymentId, {headers: header});
    }

    getPaymentsByAccountId(): Observable<Payment[]>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        let accountId = Number(localStorage.getItem("accountId"));
        
        return this._http.get<Payment[]>(this.baseUrl + "/payment/paymentList/" + accountId, {headers: header});
    }

    updatePayment(updatePayment: UpdatePaymentRequest): Observable<any>{
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.put(this.baseUrl + "/payment/updatePayment", updatePayment, {headers: header});
    }

    deletePayment(paymentId: number){
        let token = localStorage.getItem("token");
        let header = new HttpHeaders({
            "Authorization": "Bearer "+ token
        });
        
        return this._http.delete(this.baseUrl + "/payment/deletePayment/" + paymentId, {headers: header});
    }
}
