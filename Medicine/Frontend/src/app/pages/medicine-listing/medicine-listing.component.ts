import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { MedicineService } from '../../services/medicine.service';
import { IMedicine } from '../../models/medicine';
import { RouterLink, Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-medicine-listing',
  standalone: true,
  imports: [HttpClientModule, RouterLink],
  templateUrl: './medicine-listing.component.html',
  styleUrl: './medicine-listing.component.scss'
})
export class MedicineListingComponent implements OnInit{

  datam: IMedicine[] = [];
  data: any = {}
  currentPage = 1
  totalPages = 1
  limit = 3
  tradename = ""
  
  medicineService = inject(MedicineService);
  router= inject(Router)
  activatedRoute = inject(ActivatedRoute)

  ngOnInit(){
    this.activatedRoute.queryParamMap.subscribe((paramMap: ParamMap)=>{
      
      if(paramMap.has('tradename')){
        this.tradename = paramMap.get("tradename")!
        this.data.tradename = this.tradename
        this.data.currentpage = this.currentPage
        this.data.limit = this.limit
        this.getAllMedicines(this.data);       
      }      
    })
    if(this.router.url == "/medicines"){    
      this.data.currentpage = this.currentPage
      this.data.limit = this.limit
      this.data.tradename = this.tradename
      this.getAllMedicines(this.data);      
    }      
  }

  getAllMedicines(data: any){
    this.medicineService.getAllMedicines(data).subscribe({
      next: (res: any) => {
        this.datam = res.pagedMedicines;  
        this.totalPages=res.totalPages                 
      },
      error: (error: any) => {
        console.log(error);        
      }
    })
  }

  clickDel(id: any){
    this.medicineService.deleteMedicine(id).subscribe({
      next: (res: any) => {
        this.getAllMedicines(this.data);
      },
      error: (error: any) => {
        console.log(error);        
      }
    })
  }

  prev(){
    if(this.currentPage>1){
      this.currentPage--
      this.data.currentpage = this.currentPage
      this.data.limit = this.limit
      this.data.tradename = this.tradename
      this.getAllMedicines(this.data)
    }
  }

  next(){
    if(this.currentPage<this.totalPages){
      this.currentPage++
      this.data.currentpage = this.currentPage
      this.data.limit = this.limit
      this.data.tradename = this.tradename
      this.getAllMedicines(this.data)
    }
  }
}
