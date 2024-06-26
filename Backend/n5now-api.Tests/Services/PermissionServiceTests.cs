﻿using Moq;
using n5now_api.Data;
using n5now_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5now_api.Tests.Services
{
    public class PermissionServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IElasticService> _mockElasticService;
        private readonly PermissionService _permissionService;

        public PermissionServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockElasticService = new Mock<IElasticService>();
            _permissionService = new PermissionService(_mockUnitOfWork.Object, _mockElasticService.Object);
        }

        [Fact]
        public async Task RequestPermission_ShouldAddPermission()
        {
            var permission = new Permission { /* propiedades */ };
            _mockUnitOfWork.Setup(u => u.PermissionRepository.AddPermission(permission)).ReturnsAsync(permission);

            var result = await _permissionService.RequestPermission(permission);

            Assert.NotNull(result);
            _mockUnitOfWork.Verify(u => u.PermissionRepository.AddPermission(permission), Times.Once);
            _mockElasticService.Verify(e => e.IndexPermission(permission), Times.Once);
        }

        [Fact]
        public async Task ModifyPermission_ShouldUpdatePermission()
        {
            // Arrange
            var permissionId = 1; // Asumiendo que existe un permiso con ese ID
            var updatedPermission = new Permission { Id = permissionId, /* propiedades */ };
            _mockUnitOfWork.Setup(u => u.PermissionRepository.UpdatePermission(updatedPermission)).ReturnsAsync(updatedPermission);

            // Act
            var result = await _permissionService.ModifyPermission(updatedPermission);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(permissionId, result.Id); // ID se mantiene sin modificarse
            _mockUnitOfWork.Verify(u => u.PermissionRepository.UpdatePermission(updatedPermission), Times.Once);
            _mockElasticService.Verify(e => e.IndexPermission(updatedPermission), Times.Once);
        }

        [Fact]
        public async Task GetPermissions_ShouldRetrieveAllPermissions()
        {
            // Arrange
            var permissions = new List<PermissionDetail>
            {
                new PermissionDetail { Id = 1, NombreEmpleado = "Test1", ApellidoEmpleado = "User1", TipoPermiso = 1, FechaPermiso = DateTime.Now },
                new PermissionDetail { Id = 2, NombreEmpleado = "Test2", ApellidoEmpleado = "User2", TipoPermiso = 2, FechaPermiso = DateTime.Now },
                new PermissionDetail { Id = 3, NombreEmpleado = "Test3", ApellidoEmpleado = "User3", TipoPermiso = 1, FechaPermiso = DateTime.Now }
            };
            _mockUnitOfWork.Setup(u => u.PermissionRepository.GetAllPermissionsIncludingType()).ReturnsAsync(permissions);


            // Act
            var result = await _permissionService.GetPermissionsIncludingType();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(permissions.Count, result.Count()); // Asegurar numero correcto de permisos
            _mockUnitOfWork.Verify(u => u.PermissionRepository.GetAllPermissionsIncludingType(), Times.Once);
        }

    }
}
