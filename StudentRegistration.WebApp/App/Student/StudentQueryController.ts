module App {
    export class StudentQueryController{
        Students: Student[];

        private studentService: StudentService;
        static $inject = ["StudentService"];

        constructor(studentService: StudentService) {
            this.studentService = studentService;
            this.Students = [];
            this.Get();
        }

        Get() {
            var self = this;

            var successCallback = result => {
                console.log(result);
                self.Students = result.data as Student[];
            };
            var errorCallback = error => {
                console.log(error);
            };

            self.studentService.Get()
                .then(successCallback, errorCallback);
        }
    }
    angular.module('app').controller('StudentQueryController', StudentQueryController);

}