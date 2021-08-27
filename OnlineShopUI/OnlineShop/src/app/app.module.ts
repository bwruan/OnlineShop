import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AccountSettingsComponent } from './account-settings/account-settings.component';
import { UserAccountService } from './service/user-account-service';
import { LoginSecurityComponent } from './account-settings/login-security/login-security.component';
import { YourAddressComponent } from './account-settings/your-address/your-address.component';
import { YourPaymentComponent } from './account-settings/your-payment/your-payment.component';
import { YourOrdersComponent } from './account-settings/your-orders/your-orders.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    AccountSettingsComponent,
    LoginSecurityComponent,
    YourAddressComponent,
    YourPaymentComponent,
    YourOrdersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [UserAccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
