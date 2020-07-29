$("#createFormId").validate({
    rules: {
        FirstName: {
            required: true,
           
        },
        LastName: {
            required: true

        },
        PhoneNumber: {
            required: true,
            minlength: 10
        },
        Email: {
            required: true,
            email: true
        }
    },
    messages: {
        FirstName: {
            required: "Please enter First Name"
           
        },
        LastName: {
            required: "Please enter Last Name"
            
        },
        PhoneNumber: {
            required: "Please enter Phone Number",
            minlength:"Please Enter 10 digits"
        },
        Email: {
            required: "Please enter Email",
            email: "Please enter a valid email address"

        }
    }
});