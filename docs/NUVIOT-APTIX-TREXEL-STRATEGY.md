# NuvIoT + APTIX: Artifact-First Trexel Strategy

**Status:** Working discussion notes; direction and hypotheses, not an approved implementation plan  
**Started:** 2026-11-07  
**Repository:** LagoVista/DeviceAdmin

## 1. Why revisit NuvIoT?

NuvIoT is the mature, configuration-first IoT application platform from which APTIX and AppTrex evolved. It has existing paying customers. It can be a standalone commercial product, a Trexel-managed offering, and a practical proving ground for the APTIX Intelligence Engine.

The intent is to make incremental progress without creating another large engineering workstream prematurely. Product positioning and marketing should not wait for a fully autonomous AI implementation layer.

### Capabilities already built into NuvIoT

NuvIoT can configure end-to-end IoT application concerns rather than requiring bespoke application code for each one:

- Device management, provisioning, and device configuration.
- Hosting and deploying connectivity services; secure device protocols, message ingestion, device health, and offline detection.
- Parsing and normalizing device messages into standard representations.
- Archiving raw incoming data.
- Processing data with rules, thresholds, state machines, scripting, and more complex business or financial transactions.
- Sending commands and signals from the cloud to devices.
- Performing reliable remote firmware updates.
- Visualizing data and operational outcomes.

Individual elements can appear easy to prototype in code. The value proposition is the integrated, industrial-strength behavior required to run and maintain these systems in production.

## 2. The historic adoption obstacle

The principal barrier was not missing features. An implementation partner had to learn a large interconnected vocabulary of IoT concepts, understand which configuration objects represented each concern, and map customer requirements into the right entities and relationships.

A customer knows the outcome they need; they generally do not know how to assemble a listener, parser, device configuration, pipeline, rules, and deployment into a reliable solution.

**Hypothesis:** Trexels can bridge customer intent and existing NuvIoT configuration, substantially reducing this knowledge-transfer and implementation burden.

## 3. The critical lifecycle distinction: two classes of IoT Trexels

These roles serve different people and should not be collapsed into one generic "IoT assistant."

| | Design-Time Trexels | Runtime Trexels |
| --- | --- | --- |
| **Audience** | Solution architects, developers, implementation partners | Operations staff, support teams, field technicians, business users |
| **Mission** | Help design and build a production IoT application | Help provision, operate, and support deployed applications and devices |
| **Typical work** | Device and protocol models, message definitions, parsing, pipelines, FSMs, scripting, solution and deployment configurations | Device provisioning, connectivity diagnosis, status/health, notification configuration, command execution, firmware rollout and troubleshooting |
| **Primary outcome** | A coherent, validated application configuration | A reliably operating fleet and faster resolution of operational needs |
| **Change authority** | Design-time configuration changes, subject to workflow and review | Scoped operational actions with appropriate authorization and safeguards |

Examples:

- **Design time:** "Help me build a refrigeration-monitoring solution for 500 devices, with temperature alerts and remote firmware updates."
- **Runtime:** "Why did 17 devices stop reporting this morning?" or "Provision these new devices and configure who gets offline notifications."

The same NuvIoT entity may be useful to both roles, but the relevant artifact view, operations, context, permissions, and language may differ. Runtime Trexels should not require the user to understand the underlying architecture to do operational work.

## 4. Artifacts are the Trexel-facing world

**Non-negotiable principle:** Trexels begin with artifacts. They may follow an artifact to the underlying first-class entity when authorized work requires it, but the entity is not the first interface presented to the Trexel.

The existing APTIX artifact ecosystem already provides organization, durable produced artifacts, semantic indexing in the VectorDB, discovery, and reuse.

Proposed information flow:

1. A NuvIoT first-class entity remains the authoritative configuration or operational record.
2. An Artifact Specification describes how that entity is represented meaningfully for APTIX.
3. The existing producer and a suitable mapper/content factory create or update a ProducedArtifact when its source changes.
4. The ProducedArtifact is indexed and discoverable through APTIX's artifact and VectorDB capabilities.
5. A Trexel discovers and reasons from artifacts first; when needed, it follows source identity and an authorized operation to the actual NuvIoT entity.

**Do not broadly suppress artifact production to avoid "noise."** Relevant first-class entity changes should maintain their artifact representations. Any exclusions should be explicit and justified. At the same time, artifacts are point-in-time representations of first-class entities, not a competing configuration store or a promise that every high-volume telemetry event needs a distinct indexed artifact.

### What an IoT artifact should teach

Beyond the entity's raw properties, the artifact should help a Trexel answer:

- What capability does this object provide, and when should it be used?
- How does it relate to other NuvIoT configuration objects?
- What must exist before it can be created or activated?
- Which design-time or runtime tasks use it?
- Which operations are safe, supported, and authorized?
- What does successful configuration or operation look like?
- Where is the authoritative source entity, including its identity and scope?

This is the domain knowledge implementation partners historically found difficult to acquire.

## 5. We already have a machine-readable foundation

NuvIoT configuration consistently uses the **EntityBase**, **EntityDescription**, and **FormField** patterns. Nested configuration models also use metadata such as **IFormDescriptor**, and relationships can be expressed through constructs such as **FKeyProperty**.

The primary repositories to inventory are:

1. [LagoVista/DeviceAdmin](https://github.com/LagoVista/DeviceAdmin)
2. [LagoVista/DeviceMessagingAdmin](https://github.com/LagoVista/DeviceMessagingAdmin)
3. [LagoVista/DeviceManagement](https://github.com/LagoVista/DeviceManagement)
4. [LagoVista/Deployments](https://github.com/LagoVista/Deployments)
5. [LagoVista/PipelineManagement](https://github.com/LagoVista/PipelineManagement)

**Initial estimate:** Approximately 50-75 major building blocks, to be validated by inventory. Count first-class configuration entities separately from nested helper models, summaries, and runtime records.

Existing implementation seams in [LagoVista/ai](https://github.com/LagoVista/ai) include:

- **SystemEntityArtifactSpecBuilderService:** suggests Artifact Specifications for known system entities.
- **SystemEntityProducedArtifactService:** produces detail artifacts from a first-class entity.
- **ISystemEntityArtifactContentFactory:** enables deterministic/custom content production where appropriate.
- **ProducedArtifactWriter:** persists and versions produced artifacts and supports indexing.
- **SystemEntity / SystemEntityCatalog** output classifications: distinguish one-entity snapshots from scoped collections. The catalog producer is a separate, not-yet-implemented path and should not be treated as automatic save behavior.

Reference: [First-Class Entity Artifacts](https://github.com/LagoVista/ai/blob/master/docs/first-class-entity-artifacts.md).

The likely job is to use these existing components, inventory coverage, fill missing specifications/mappings, and improve their domain semantics—not to create a parallel NuvIoT knowledge platform.

## 6. Two useful layers of artifact meaning

**Platform/configuration artifacts** describe NuvIoT's real building blocks: device configuration, listener, message definition, planner, processing module, firmware configuration, deployment, and related concepts.

**Solution/outcome artifacts** describe what the customer wants to accomplish: a device connectivity design, telemetry-processing plan, notification strategy, rollout plan, or end-to-end IoT solution blueprint. These may reference multiple platform artifacts and their relationships.

These are conceptual layers, not a proposal to duplicate or replace existing NuvIoT entities. Different Artifact Specifications may provide different legitimate lenses on the same underlying source.

## 7. Commercial and marketing opportunity

NuvIoT should be explored as a standalone revenue-generating IoT product **and** as an AppTrex/Trexel-managed service. Existing customers give us a real business and a credible proving ground.

A Marketing Trexel team could use product documentation and grounded artifacts to investigate:

- Ideal Customer Profiles and distinct design-time versus runtime buyers.
- Market segments where configuration-first, production-ready IoT infrastructure is particularly valuable.
- Competitive alternatives, including custom development.
- Outcome-led positioning, use cases, demonstrations, and campaigns.
- The business case for an ongoing AI-assisted operations service.

The exercise also tests whether AppTrex Marketing Trexels can develop evidence-based go-to-market work for a real product. Do not assume the historical customer profile is automatically the ideal future buyer.

## 8. Small, incremental next steps (proposals only)

1. **Inventory** the five repositories: first-class entity types, nested types, relationship metadata, and available REST/factory metadata.
2. **Audit artifact coverage:** which types already have Artifact Specifications, automatic production, useful content, and VectorDB indexing? Identify gaps rather than duplicating existing work.
3. **Classify** each candidate by design-time, runtime, or both; identify audience-specific behavior and required authority.
4. **Evaluate a narrow end-to-end slice:** device connectivity + message parsing for design time, and provisioning + connectivity/offline investigation for runtime.
5. **Refine artifact content and mappings:** ensure artifacts explain purpose, dependencies, relationships, and supported operations, not only serialized properties.
6. **Give Marketing Trexels a bounded research assignment** to explore the NuvIoT ideal customer profile using verified product facts.

These are exploration steps, not assigned tasks, an approved workstream, or an implementation schedule.

## 9. Questions to resolve as we learn

- What percentage of first-class NuvIoT entities already have useful Artifact Specifications and generated artifacts?
- Which entity types merit multiple artifact perspectives for different audiences?
- Can the existing metadata and relationships drive most specification generation, and where is supplemental "when/why" guidance needed?
- What is the right way to expose high-volume operational data as meaningful, indexed summaries without confusing it with configuration entities?
- How should runtime actions be constrained by organization, user role, device scope, audit, and approval policy?
- What customer segments have the strongest pain around IoT implementation and ongoing fleet operation?

---

**Guiding principle:** Leverage the mature NuvIoT platform and existing APTIX artifact infrastructure. Make NuvIoT understandable and actionable through Trexels, while incrementally validating both product demand and APTIX capabilities.
