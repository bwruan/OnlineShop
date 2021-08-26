import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountSettingsComponent } from './account-settings/account-settings.component';
import { LoginSecurityComponent } from './account-settings/login-security/login-security.component';
import { YourAddressComponent } from './account-settings/your-address/your-address.component';
import { YourOrdersComponent } from './account-settings/your-orders/your-orders.component';
import { YourPaymentComponent } from './account-settings/your-payment/your-payment.component';

const routes: Routes = [
  {path: "accountsetting", component: AccountSettingsComponent, children: [
    {path: 'loginSecurity', component: LoginSecurityComponent},
    {path: 'yourAddress', component: YourAddressComponent},
    {path: 'yourPayment', component: YourPaymentComponent},
    {path: 'yourOrders', component: YourOrdersComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
