import { UserObject } from './user-object';
import { StudentObject } from './student-object';

export class ParentObject extends UserObject {

    Student: StudentObject;

    public constructor() {
        super();
        this.Student = new StudentObject();
    }
}
