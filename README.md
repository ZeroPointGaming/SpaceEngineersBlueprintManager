# Space Engineers Blueprint Manager

A desktop application built to analyze, interpret, and visualize Space Engineers blueprint files, providing detailed breakdowns of block composition, material requirements, processing time calculations, and modded content integration.

This project demonstrates advanced XML serialization techniques, complex data modeling, mathematical resource analysis, and deep integration with a game’s modding ecosystem.

---

## Overview

Space Engineers Blueprint Manager was created to give players and engineers deeper insight into the true cost and complexity of their creations. The application loads Space Engineers blueprint files and reconstructs their full structural composition, including vanilla and modded blocks, then performs detailed calculations to determine required raw materials, component counts, and processing time.

The system goes beyond simple blueprint parsing by dynamically reading installed mod definitions to fully support modded blocks, their visual assets, and their unique material requirements.

---

## Core Capabilities

- Blueprint file loading and interpretation
- Detailed block composition analysis
- Raw material requirement calculations
- Component and ingot breakdowns
- Refinery and assembler processing time estimation
- Block count summaries by type
- Full support for modded blocks
- Visual display of blocks including mod provided icons
- Data driven and extensible architecture

---

## Technical Architecture

All core functionality is located within:

---

### XML Serialization and Blueprint Parsing

Space Engineers blueprints are stored as complex XML documents with nested structures and game specific schemas. This project implements heavily customized XML serialization logic to safely deserialize and interpret these files while maintaining compatibility across blueprint variations.

Custom serializers are responsible for:
- Interpreting cube grid definitions
- Extracting block metadata
- Handling optional and mod specific nodes
- Normalizing data into internal models for processing

---

### Mod Awareness and Integration

One of the most complex aspects of this project is its ability to understand and process modded content.

The application scans the user’s local Space Engineers mod directory and dynamically loads mod XML definitions to extract:

- Custom block definitions
- Component recipes
- Raw material requirements
- Block icons and textures
- Mod specific metadata

This system allows modded blocks to be treated as first class citizens in all calculations and visual displays.

---

## Mathematical Resource Calculations

The application performs extensive calculations to convert blueprint data into meaningful engineering metrics, including:

- Total component counts
- Ingot and ore requirements
- Conversion ratios across production chains
- Refinery and assembler processing time estimates
- Aggregated totals across multiple grids and subgrids

These calculations model real in game production mechanics, allowing users to accurately plan resource gathering and manufacturing workflows.

---

## Technologies Used

- Visual Basic .NET
- Windows Forms
- Custom XML Serialization
- Game Data Reverse Engineering
- Mathematical Modeling and Analysis
- File System Scanning and Asset Extraction

---

## Use Case

This project serves both as a functional engineering tool for Space Engineers players and as a technical demonstration of advanced data parsing, serialization, and systems modeling in a desktop application environment.

It showcases the ability to work with undocumented or semi documented data formats, integrate external content systems, and translate raw data into actionable engineering insights.

---

## Notes

- Designed to work with local Space Engineers blueprint and mod files.
- Supports both vanilla and modded gameplay environments.
- Accuracy depends on the correctness of installed mod definitions.
- The project is intended as a technical and engineering showcase.

---

## Author

Developed as part of a professional software engineering portfolio to demonstrate advanced XML processing, complex data modeling, mathematical analysis, and deep integration with third party content systems.
