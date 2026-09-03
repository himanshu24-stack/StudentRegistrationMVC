namespace StudentRegistrationMVC.Models
{
    public class Student
    {
        // ==========================================
        // 1. Primary Key
        // ==========================================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        // ==========================================
        // 2. Personal Information
        // ==========================================
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters.")]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Blood Group is required.")]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Email must be valid.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Mobile number must be valid.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be a valid 10-digit number.")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = string.Empty;

        // ==========================================
        // 3. Address Information
        // ==========================================
        [Required(ErrorMessage = "Address is required.")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        [Display(Name = "Residential Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters.")]
        [Display(Name = "State")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pincode is required.")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Pincode must contain a valid 6-digit number.")]
        [Display(Name = "Pincode")]
        public string Pincode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; } = "India";

        // ==========================================
        // 4. Academic Information
        // ==========================================
        [Required(ErrorMessage = "Course selection is required.")]
        [Display(Name = "Course")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department selection is required.")]
        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Semester selection is required.")]
        [Display(Name = "Semester")]
        public string Semester { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enrollment Number is required.")]
        [StringLength(30, ErrorMessage = "Enrollment Number cannot exceed 30 characters.")]
        [Display(Name = "Enrollment Number")]
        public string EnrollmentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Previous School/College name is required.")]
        [StringLength(150, ErrorMessage = "Previous Institution cannot exceed 150 characters.")]
        [Display(Name = "Previous School / College")]
        public string PreviousSchoolCollege { get; set; } = string.Empty;

        [Required(ErrorMessage = "Percentage is required.")]
        [Range(0.00, 100.00, ErrorMessage = "Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Previous Percentage (%)")]
        public decimal? Percentage { get; set; }

        // ==========================================
        // 5. Parent/Guardian Information
        // ==========================================
        [Required(ErrorMessage = "Father's Name is required.")]
        [StringLength(50, ErrorMessage = "Father's Name cannot exceed 50 characters.")]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mother's Name is required.")]
        [StringLength(50, ErrorMessage = "Mother's Name cannot exceed 50 characters.")]
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Guardian Name cannot exceed 50 characters.")]
        [Display(Name = "Guardian's Name")]
        public string? GuardianName { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Guardian Mobile Number must be a valid 10-digit number.")]
        [Display(Name = "Guardian Mobile Number")]
        public string? GuardianMobileNumber { get; set; }

        // ==========================================
        // 6. Additional Information
        // ==========================================
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Hobbies cannot exceed 250 characters.")]
        [Display(Name = "Hobbies / Interests")]
        public string? Hobbies { get; set; }

        [Display(Name = "Is Hosteller?")]
        public bool IsHosteller { get; set; } = false;

        [StringLength(100, ErrorMessage = "Hostel Name cannot exceed 100 characters.")]
        [Display(Name = "Hostel Name")]
        public string? HostelName { get; set; }

        [Required(ErrorMessage = "Emergency contact person name is required.")]
        [StringLength(50, ErrorMessage = "Emergency Contact Name cannot exceed 50 characters.")]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Emergency Contact Number must be a valid 10-digit number.")]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; } = string.Empty;

        // Auto-recorded registration timestamp
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Helper computed property for full name
        [NotMapped]
        public string FullName => string.IsNullOrWhiteSpace(MiddleName)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";
    }
}
