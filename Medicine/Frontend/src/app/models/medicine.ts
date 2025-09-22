export interface IMedicine { 
    medicineId: number,
    medicineTradeName: string,
    medicineInterName: string,
    medicineManufacturer: any,   
    medicineForm: any,    
    medSubstances: any[],
    medDoses: any[],
    medicineImageUrl: string  
}

export class Medicine {
    medicineId: number;
    medicineTradeName: string;
    interName: string;
    medicineManufacturer: any;   
    medicineForm: any;    
    medSubstances: any[];
    medDoses: any[];
    medicineImageUrl: string; 

    constructor(){
        this.medicineId = 0,
        this.medicineTradeName = "",
        this.interName = "",
        this.medicineManufacturer = {},   
        this.medicineForm = 0,    
        this.medSubstances = [],
        this.medDoses = [],
        this.medicineImageUrl = "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg"  
    }

}