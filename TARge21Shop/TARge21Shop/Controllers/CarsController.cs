using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
	public class CarsController : Controller
	{
		private readonly TARge21ShopContext _context;
		private readonly ICarsServices _carsServices;

		public CarsController
			(
				TARge21ShopContext context,
				ICarsServices carsServices
			)
		{
			_context = context;
			_carsServices = carsServices;
		}

		public IActionResult Index()
		{
			var result = _context.Cars
				.OrderByDescending(y => y.BuiltDate)
				.Select(x => new CarIndexViewModel
				{
					Id = x.Id,
					Brand = x.Brand,
					Model = x.Model,
					Color = x.Color,
					FuelType = x.FuelType,
					Price = x.Price,
					EnginePower = x.EnginePower,
					Mileage = x.Mileage,
					PreviousOwners = x.PreviousOwners,
					BuiltDate = x.BuiltDate,
					MaintanceDate = x.MaintanceDate,
				});

			return View(result);
		}


		[HttpGet]
		public IActionResult Create()
		{
			CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

			return View("CreateUpdate", car);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
		{
			var dto = new CarDto()
			{
				Id = vm.Id,
				Brand = vm.Brand,
				Model = vm.Model,
				Color = vm.Color,
				FuelType = vm.FuelType,
				Price = vm.Price,
				EnginePower = vm.EnginePower,
				Mileage = vm.Mileage,
				PreviousOwners = vm.PreviousOwners,
				BuiltDate = vm.BuiltDate,
				MaintanceDate = vm.MaintanceDate,
				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt,
			};

			var result = await _carsServices.Create(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}


		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarCreateUpdateViewModel()
			{
				Id = car.Id,
				Brand = car.Brand,
				Model = car.Model,
				Color = car.Color,
				FuelType = car.FuelType,
				Price = car.Price,
				EnginePower = car.EnginePower,
				Mileage = car.Mileage,
				PreviousOwners = car.PreviousOwners,
				BuiltDate = car.BuiltDate,
				MaintanceDate = car.MaintanceDate,
				CreatedAt = car.CreatedAt,
				ModifiedAt = car.ModifiedAt,
			};

			return View("CreateUpdate", vm);
		}


		[HttpPost]
		public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
		{
			var dto = new CarDto()
			{
				Id = vm.Id,
				Brand = vm.Brand,
				Model = vm.Model,
				Color = vm.Color,
				FuelType = vm.FuelType,
				Price = vm.Price,
				EnginePower = vm.EnginePower,
				Mileage = vm.Mileage,
				PreviousOwners = vm.PreviousOwners,
				BuiltDate = vm.BuiltDate,
				MaintanceDate = vm.MaintanceDate,
				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt,
			};

			var result = await _carsServices.Update(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}


		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarDetailsViewModel()
			{
				Id = car.Id,
				Brand = car.Brand,
				Model = car.Model,
				Color = car.Color,
				FuelType = car.FuelType,
				Price = car.Price,
				EnginePower = car.EnginePower,
				Mileage = car.Mileage,
				PreviousOwners = car.PreviousOwners,
				BuiltDate = car.BuiltDate,
				MaintanceDate = car.MaintanceDate,
				CreatedAt = car.CreatedAt,
				ModifiedAt = car.ModifiedAt,
			};

			return View(vm);
		}


		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var car = await _carsServices.GetAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarDeleteViewModel()
			{
				Id = car.Id,
				Brand = car.Brand,
				Model = car.Model,
				Color = car.Color,
				FuelType = car.FuelType,
				Price = car.Price,
				EnginePower = car.EnginePower,
				Mileage = car.Mileage,
				PreviousOwners = car.PreviousOwners,
				BuiltDate = car.BuiltDate,
				MaintanceDate = car.MaintanceDate,
				CreatedAt = car.CreatedAt,
				ModifiedAt = car.ModifiedAt,
			};

			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var carId = await _carsServices.Delete(id);

			if (carId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}