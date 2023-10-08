

function generateCaptcha() {
    var num1 = Math.floor(Math.random() * 10);
    var num2 = Math.floor(Math.random() * 10);
    var operation = ['+', '-', '*', '/'][Math.floor(Math.random() * 4)];
    var result = 0;

    switch (operation) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            // Avoid division by zero
            if (num2 === 0) {
                num2 = 1;
            }
            result = num1 / num2;
            break;
    }

    document.getElementById("captcha-question").innerHTML = num1 + " " + operation + " " + num2 + " = ?";
    document.getElementById("captcha-result").value = result;
}

// Function to validate the CAPTCHA
function validateCaptcha() {
    var userAnswer = parseInt(document.getElementById("user-captcha").value);
    var correctAnswer = parseInt(document.getElementById("captcha-result").value);

    if (userAnswer === correctAnswer) {
        alert("CAPTCHA Verification Successful. You can now proceed.");
    } else {
        alert("CAPTCHA Verification Failed. Please try again.");
        generateCaptcha();
    }
}





function validateMobileNumber() {
    var mobileNumber = document.getElementById("patientPhone").value;
    var regex = /^[0-9]{10}$/; // 10-digit numeric pattern

    if (!regex.test(mobileNumber)) {
        alert("Please enter a valid 10-digit mobile number.");
        return false;
    }
    return true;
}

function validatePassword() {
    var password = document.getElementById("patientPassword").value;
    var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/; // Password complexity pattern

    if (!regex.test(password)) {
        alert("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, and one digit.");
        return false;
    }
    return true;
}

function validateEmail() {
    var email = document.getElementById("patientEmail").value;
    var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/; // Email format pattern

    if (!regex.test(email)) {
        alert("Please enter a valid email address.");
        return false;
    }
    return true;
}


document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("resetPasswordForm").addEventListener("submit", function (event) {
        event.preventDefault(); // Prevent the form from submitting by default

        // Get input values
        var newPassword = document.getElementById("inputPassword").value;
        var confirmPassword = document.getElementById("inputConfirmPassword").value;

        // Check if passwords match
        if (newPassword !== confirmPassword) {
            // Display an error message
            var errorMessage = document.getElementById("errorMessage");
            errorMessage.innerHTML = '<div class="alert alert-dismissible alert-danger"><button type="button" class="close" data-dismiss="alert">&times;</button><strong>Passwords do not match!</strong></div>';

            // Clear password fields
            document.getElementById("inputPassword").value = "";
            document.getElementById("inputConfirmPassword").value="";

            // Prevent form submission
            return false;
        }

      
        // If passwords match, submit the form
        this.submit();
    });
});



