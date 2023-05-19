using Microsoft.AspNetCore.Mvc;
using StaffAPI.Core.Entities;
using StaffAPI.Services.Interfaces;
using StaffAPI.Validation;

namespace StaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        /// <summary>
        /// Get the list of staff
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffList = await _staffService.GetAllStaffs();
            if (staffList == null)
            {
                return NotFound();
            }
            return Ok(staffList);
        }

        /// <summary>
        /// Get staff by id
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        [HttpGet("{staffId}")]
        public async Task<IActionResult> GetById(int staffId)
        {
            var staff = await _staffService.GetStaffById(staffId);

            if (staff != null)
            {
                return Ok(staff);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Staff staff)
        {
            StaffValidator validator = new StaffValidator();
            var validationResult = validator.Validate(staff);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var isStaffCreated = await _staffService.CreateStaff(staff);

            if (isStaffCreated)
            {
                return Ok(isStaffCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(Staff staff)
        {
            StaffValidator validator = new StaffValidator();
            var validationResult = validator.Validate(staff);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (staff != null)
            {
                var isProductUpdated = await _staffService.UpdateStaff(staff);
                if (isProductUpdated)
                {
                    return Ok(isProductUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete staff by id
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        [HttpDelete("{staffId}")]
        public async Task<IActionResult> Delete(int staffId)
        {
            var isStaffDeleted = await _staffService.DeleteStaff(staffId);

            if (isStaffDeleted)
            {
                return Ok(isStaffDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
