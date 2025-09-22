import { CommonModule, NgIf } from '@angular/common';
import { Component, NgModule, inject } from '@angular/core';
import { SubstanceService } from '../../services/substance.service';
import { MedicineService } from '../../services/medicine.service';
import { FormControl,  FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IDropdownSettings, NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { IMedicine } from '../../models/medicine';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-update',
  standalone: true,
  imports: [ReactiveFormsModule, NgMultiSelectDropDownModule, NgIf, CommonModule, FormsModule],
  templateUrl: './form-update.component.html',
  styleUrl: './form-update.component.scss'
})
export class FormUpdateComponent {

  medicineService = inject(MedicineService);
  substanceService = inject(SubstanceService);
  route = inject(ActivatedRoute)
  router= inject(Router)
  dataSingle: IMedicine | undefined;
  medObj: any = {    
    "tradeName": "",
    "interName": "",
    "medicineId": 0,
    "manufacturerId": 0,
    "manufacturerName": "",   
    "medFormId": "", 
    "medFormName":"",   
    "substanceIds": [],
    "doseIds": [],
    "imageUrl": "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg",
  }

  updateForm!: FormGroup;
  tmp2: any[]= [];
  tmp1: any[]= [];
  medId: any;
  dropdownSettings: IDropdownSettings={};
  dropdownDoseSettings: IDropdownSettings={};
  dropdownList:any = [];
  dropdownDoseList:any = [];
  DoseItems:any = [];
  SubstanceItems:any = [];
  manufacturersList:any = [];
  medformsList:any = [];
  requiredField: boolean = false;
  requiredFieldDose: boolean = false;
  isFormSubmitted: boolean = false;

  ngOnInit(){
    this.route.paramMap.subscribe((params)=>{
      this.medId = params.get('id')
    }) 
    this.getAllDoses();
    this.getAllSubstances(); 
    this.getAllManufacturers(); 
    this.getAllMedForms();
    this.getMedicine();

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

  getAllMedForms(){
    this.medicineService.getAllMedForms().subscribe({
      next: (res: any) => {
        this.medformsList = res;
      }, error: (error: any) => {
        console.log(error);        
      }
    })
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

  getMedicine(){
    
    this.medicineService.getMedicineById(this.medId).subscribe({
      next: (res: any) => {
        this.dataSingle = res;
        let substanceArr = res?.medSubstances;
        let doseArr = res?.medDoses;
        this.medObj = {
          "tradeName": this.dataSingle?.medicineTradeName,
          "interName": this.dataSingle?.medicineInterName,
          "medId": this.dataSingle?.medicineId,
          "manufacturerId": this.dataSingle?.medicineManufacturer.manufacturerId,
          "manufacturerName": this.dataSingle?.medicineManufacturer.manufacturerName,   
          "medFormId": this.dataSingle?.medicineForm.id, 
          "medFormName": this.dataSingle?.medicineForm.title,   
          "substanceIds": [],
          "doseIds": [],
          "imageUrl": this.dataSingle?.medicineImageUrl,
        } 

        for(let i=0; i<substanceArr.length; i++) {            
          this.tmp1.push({substanceId: substanceArr[i].id, tradeName: substanceArr[i].tradeName});
        }; 

        for(let i=0; i<doseArr.length; i++) {  
          this.tmp2.push({doseId: doseArr[i].id, title: doseArr[i].dosage+" "+doseArr[i].title, })
        }; 

        this.updateForm = new FormGroup({
          tradeName: new FormControl(this.medObj.tradeName, [Validators.required]),
          interName: new FormControl(this.medObj.interName, [Validators.required]),
          manufacturer: new FormControl(this.medObj.manufacturerId),
          medForm: new FormControl(this.medObj.medFormId),
          substance: new FormControl(this.tmp1),
          doses: new FormControl(this.tmp2),
          imageUrl: new FormControl(this.medObj.imageUrl),
        });
      },

      error: (error: any) => {
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

  onUpdate(){

    this.updateForm.value.substance.forEach((item: any) => {
      this.medObj.substanceIds.push(item.substanceId);      
    });

    this.updateForm.value.doses.forEach((item: any) => {
      this.medObj.doseIds.push(item.doseId);      
    });

    this.medObj.tradeName = this.updateForm.value.tradeName
    this.medObj.interName = this.updateForm.value.interName
    this.medObj.manufacturerId = this.updateForm.value.manufacturer
    this.medObj.medFormId = this.updateForm.value.medForm
    this.medObj.imageUrl = this.updateForm.value.imageUrl

    console.log(this.medObj.imageUrl);
    

    this.medicineService.onUpdate(this.medObj).subscribe({
      next: (res: any) => {
        this.router.navigate(['/medicines']);
      },
      error: (error: any) => {
        console.log(error);        
      }
    })
  }
}
