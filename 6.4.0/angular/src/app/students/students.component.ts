import { EditStudentDialogComponent } from './editStudentDialog/editStudentDialog.component';
import { CreateStudentDialogComponent } from './createStudentDialog/createStudentDialog.component';
import { AppComponentBase } from '@shared/app-component-base';
import { StudentDto, StudentManagerServiceProxy } from './../../shared/service-proxies/service-proxies';
import { Component, Injector, OnInit } from '@angular/core';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';







@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css'],
  animations: [appModuleAnimation()]
})
export class StudentsComponent extends AppComponentBase implements OnInit {
  students: StudentDto[] = [];
  
  constructor(
    injector: Injector,
    private _studentService: StudentManagerServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(){
    this.retrieveStudents();
  }

  retrieveStudents(){
    this._studentService.getStudents().subscribe(result =>{
        this.students = result;
    })
  }

  createStudent(): void {
    this.showCreateOrEditUserDialog();
  }

  editStudent(student: StudentDto): void {
    this.showCreateOrEditUserDialog(student.id);
  }

  // public resetPassword(user: UserDto): void {
  //   this.showResetPasswordUserDialog(user.id);
  // }

  

 
//delete a student
  protected delete(student: StudentDto): void {
    abp.message.confirm(
      this.l('Student'+' '+ student.firstName + ' ' + student.lastName + ' will be deleted'),
      undefined,
      (result: boolean) => {
        if (result) {
          this._studentService.deleteStudent(student.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  refresh(){
    window.location.reload();
  }

  

  private showCreateOrEditUserDialog(id?: number): void {
    let createOrEditStudentDialog: BsModalRef;
    if (!id) {
      createOrEditStudentDialog = this._modalService.show(
        CreateStudentDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditStudentDialog = this._modalService.show(
        EditStudentDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditStudentDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
