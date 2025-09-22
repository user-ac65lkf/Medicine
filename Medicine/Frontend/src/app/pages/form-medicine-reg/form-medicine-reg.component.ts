import { Component, OnInit, inject } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MedicineService } from '../../services/medicine.service';
import { IDropdownSettings, NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { SubstanceService } from '../../services/substance.service';
import { CommonModule, NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-medicine-reg',
  standalone: true,
  imports: [FormsModule, HttpClientModule, NgMultiSelectDropDownModule, CommonModule, NgIf],
  templateUrl: './form-medicine-reg.component.html',
  styleUrl: './form-medicine-reg.component.scss'
})
export class FormMedicineRegComponent implements OnInit{

  dropdownSettings:IDropdownSettings={};
  dropdownDoseSettings:IDropdownSettings={};
  dropdownList:any = [];
  dropdownDoseList:any = [];
  selectedDoseItems:any = [];
  selectedItems:any = [];
  manufacturersList:any = [];
  medformsList:any = [];
  isFormSubmitted: boolean = false
  requiredField: boolean = false;
  requiredFieldDose: boolean = false;

  medObj: any = {
    "tradeName": "",
    "interName": "",
    "manufacturerId": 0,   
    "medFormId": "",    
    "substanceIds": [],
    "doseIds": [],
    "imageUrl": "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg",
  }

  medicineService = inject(MedicineService);
  substanceService = inject(SubstanceService);
  router= inject(Router)

  ngOnInit(): void {

    this.getAllSubstances();
    this.getAllManufacturers();
    this.getAllDoses();
    this.getAllMedForms();

    this.dropdownSettings = {
      singleSelection: false,
      enableCheckAll:false,
      idField: 'substanceId',
      textField: 'tradeName',
      itemsShowLimit: 3,
      allowSearchFilter: true
    }; 

    this.dropdownDoseSettings = {
      singleSelection: false,
      enableCheckAll:false,
      idField: 'doseId',
      textField: 'title',
      itemsShowLimit: 3,
      allowSearchFilter: true
    }; 
    
  }

  getAllManufacturers(){
    this.medicineService.getAllManufacturers().subscribe({
      next: (res: any) => {
        this.manufacturersList = res;
      }, error: (error: any) => {
        console.log(error);        
      }
    })
  }

  getAllMedForms(){
    this.medicineService.getAllMedForms().subscribe({
      next: (res: any) => {
        this.medformsList = res;
      }, error: (error: any) => {
        console.log(error);        
      }
    })
  }

  getAllDoses(){
    let tmp = [];
    this.medicineService.getAllDoses().subscribe({
      next: (res: any) => {

        for(let i=0; i<res.length; i++){
          tmp.push({doseId: res[i].id, title: res[i].dosage+" "+res[i].title, })
        }
        this.dropdownDoseList = tmp                   
      },
      error: (error: any) => {
        console.log(error);        
      }
    })
  }

  getAllSubstances(){
    let tmp = [];
    this.substanceService.getAllSubstances().subscribe({
      next: (res: any) => {
        for(let i=0; i<res.length; i++){
          tmp.push({substanceId: res[i].id, tradeName: res[i].tradeName})
        }
        this.dropdownList = tmp                   
      },
      error: (error: any) => {
        console.log(error);        
      }
    })
  }

  onRegister(form: any){ 
    this.isFormSubmitted = true
    if(form.valid && this.requiredField==true && this.requiredFieldDose==true){
      this.medicineService.onRegister(this.medObj).subscribe({
        next: (res: any) => {
          console.log(res); 
          this.router.navigate(['/medicines']);                   
        },
        error: (error: any) => {
          console.log(error);        
        }
      })
    }
  }
  setStatus(str: string) {   
    if(str=="substance"){
      (this.selectedItems.length > 0) ? this.requiredField = true : this.requiredField = false; 
    }
    if(str=="dose"){
      (this.selectedDoseItems.length > 0) ? this.requiredFieldDose = true : this.requiredFieldDose = false; 
    }
  }

  onItemSelect(item: any) {    
    this.medObj.substanceIds.push(item.substanceId);
    this.setStatus("substance")
  }

  onItemDeSelect(item: any) {           
    this.medObj.substanceIds = this.medObj.substanceIds.filter( (el: { id: any; }) => {   
        return el != item.substanceId
    })
    this.setStatus("substance")
  }

  onItemDoseSelect(item: any){
    this.medObj.doseIds.push(item.doseId);
    this.setStatus("dose")
  }

  onItemDoseDeSelect(item: any){
    this.medObj.doseIds = this.medObj.doseIds.filter( (el: { id: any; }) => {   
      return el != item.doseId
    })
    this.setStatus("dose")
  }

}
