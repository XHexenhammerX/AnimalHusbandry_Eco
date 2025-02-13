// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]												  														 
    [RequireRoomContainment]
    [RequireRoomVolume(45)]
    [RequireRoomMaterialTier(2.8f, typeof(ButcheryLavishReqTalent), typeof(ButcheryFrugalReqTalent))]
    [Ecopedia("Housing Objects", "Kitchen", subPageName: "ElectricButcheryTable Item")]
    public partial class ElectricButcheryTableObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ElectricButcheryTableItem);
        public override LocString DisplayName => Localizer.DoStr("Electric Butchery Table");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Cooking"));
            this.GetComponent<HousingComponent>().HomeValue = ElectricButcheryTableItem.homeValue;
            this.GetComponent<PowerConsumptionComponent>().Initialize(250);
            this.GetComponent<PowerGridComponent>().Initialize(15, new ElectricPower());
            this.ModsPostInitialize();
        }
        static ElectricButcheryTableObject()
		{
			AddOccupancy<ElectricButcheryTableObject>(new List<BlockOccupancy>()
            {
            new BlockOccupancy(new Vector3i(-1, 0, 0)),
            new BlockOccupancy(new Vector3i(-1, 1, 0)),
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
			});
		}

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Electric Butchery Table")]
    [Ecopedia("Housing Objects", "Kitchen", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [AllowPluginModules(Tags = new[] { "ModernUpgrade" }, ItemTypes = new[] { typeof(ModernButcheryUpgradeItem) })] //noloc
    public partial class ElectricButcheryTableItem : WorldObjectItem<ElectricButcheryTableObject>, IPersistentData
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("An Electric Butchery table to process raw meat into fancier dishes.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = HousingConfig.GetRoomCategory("Kitchen"),
            HouseValue               = 4,
            TypeForRoomLimit         = Localizer.DoStr("Food Preparation"),
            DiminishingReturnPercent = 0.5f
        };

        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
    }

    /// <summary>
    /// <para>Server side recipe definition for "ElectricButcheryTable".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresSkill(typeof(IndustrySkill), 1)]
    [Ecopedia("Housing Objects", "Kitchen", subPageName: "ElectricButcheryTable Item")]
    public partial class ElectricButcheryTableRecipe : RecipeFamily
    {
        public ElectricButcheryTableRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ElectricButcheryTable",  //noloc
                Localizer.DoStr("Electric Butchery Table"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelPlateItem), 20, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),
                    new IngredientElement(typeof(SteelSawBladeItem), 2, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ElectricButcheryTableItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElectricButcheryTableRecipe), 15, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Electric Butchery Table"), typeof(ElectricButcheryTableRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
