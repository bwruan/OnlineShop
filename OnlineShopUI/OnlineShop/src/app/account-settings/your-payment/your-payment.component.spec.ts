import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YourPaymentComponent } from './your-payment.component';

describe('YourPaymentComponent', () => {
  let component: YourPaymentComponent;
  let fixture: ComponentFixture<YourPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YourPaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YourPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
