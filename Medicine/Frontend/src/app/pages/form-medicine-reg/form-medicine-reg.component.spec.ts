import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormMedicineRegComponent } from './form-medicine-reg.component';

describe('FormMedicineRegComponent', () => {
  let component: FormMedicineRegComponent;
  let fixture: ComponentFixture<FormMedicineRegComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormMedicineRegComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormMedicineRegComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
