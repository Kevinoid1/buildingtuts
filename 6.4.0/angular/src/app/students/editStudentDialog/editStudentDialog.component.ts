import { StudentDto, StudentManagerServiceProxy } from './../../../shared/service-proxies/service-proxies';
import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  UserServiceProxy,
  UserDto,
  RoleDto
} from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-editStudentDialog',
  templateUrl: './editStudentDialog.component.html',
  styleUrls: ['./editStudentDialog.component.css']
})
export class EditStudentDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  student = new StudentDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _studentService: StudentManagerServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._studentService.getStudent(this.id).subscribe(result => this.student= result);
  }

  save(): void {
    this.saving = true;
    this._studentService.updateStudent(this.student).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }

}
