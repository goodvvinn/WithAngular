import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/inspection-api.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent implements OnInit {

  inspectionList$!: Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;
  inspectionTypesList: any = [];

  inspectionTypesMap: Map<number, string> = new Map()

  constructor(private service: InspectionApiService) { }

  ngOnInit(): void {
    this.inspectionList$ = this.service.getInspectionList();
    this.inspectionTypesList$ = this.service.getInspectionTypesList();
    this.refreshInspectionTypesMap();
  }

  // Variables (properties)
  modalTitle: string = '';
  activateAddEditInspectionComponent: boolean = false;
  inspection: any;

  modalAdd() {
    this.inspection = {
      id: 0,
      status: null,
      comment: null,
      inspectionTypeId: null
    }
    this.modalTitle = "Add Inspection Results";
    this.activateAddEditInspectionComponent = true;
  }

  modalEdit(item:any){
    this.inspection = item;
    this.modalTitle = "Edit Inspection Result";
    this.activateAddEditInspectionComponent = true;
  }

  delete(item:any){
    if (confirm(`Delete Inspection result ${item.id}`)) {
      this.service.deleteInspection(item.id).subscribe(result =>{
        var closeModalBtn = document.getElementById("add-edit-modal-close");
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showDeleteSuccess = document.getElementById("delete-success-alert");
      if (showDeleteSuccess) {
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function() {
        if (showDeleteSuccess) {
            showDeleteSuccess.style.display = "none";
        }
      }, 7000);
      this.inspectionList$ = this.service.getInspectionList();
      })
    }
  }

  modalClose(){
    this.activateAddEditInspectionComponent = false;
    this.inspectionList$ = this.service.getInspectionList();
  }

  refreshInspectionTypesMap() {
    this.service.getInspectionTypesList().subscribe(data => {
      this.inspectionTypesList = data;

      for (let index = 0; index < data.length; index++) {
        this.inspectionTypesMap.set(this.inspectionTypesList[index].id, this.inspectionTypesList[index].inspectionName);

      }
    })
  }

}
